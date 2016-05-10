using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using UniversityMS.Models;
using UniversityMS.Context;

namespace UniversityMS.Controllers
{
    public class CourseAssignController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: /CourseAssign/
        public ActionResult Index()
        {
            var courseassigns = db.CourseAssigns.Include(c => c.Course).Include(c => c.Department).Include(c => c.Teacher);
            return View(courseassigns.ToList());
        }

        public ActionResult ViewCourseStatistics()
        {
            ViewBag.Departments = db.Departments.ToList();
            return View();
        }

        public JsonResult ShowCourseStatistics(int deptId)
        {
            var courses = db.Courses.Where(m => m.DepartmentId == deptId).ToList();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }


        // GET: /CourseAssign/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssign courseassign = db.CourseAssigns.Find(id);
            if (courseassign == null)
            {
                return HttpNotFound();
            }
            return View(courseassign);
        }

        // GET: /CourseAssign/Create
        public ActionResult Save()
        {
            //ViewBag.CourseID = new SelectList(db.Courses, "Id", "CourseCode");
            //ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DeptCode");
            //ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "TeacherName");

            ViewBag.Departments = db.Departments.ToList();

            return View();
        }

        public JsonResult GetTeacherByDeptId(int deptId)
        {
            var teachers = db.Teachers.Where(m => m.DepartmentId == deptId).ToList();
            return Json(teachers, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseByDeptId(int deptId)
        {
            var courses = db.Courses.Where(m => m.DepartmentId == deptId).ToList();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTeacherById(int TeacherId)
        {
            var teacher = db.Teachers.FirstOrDefault(m => m.Id == TeacherId);
            return Json(teacher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseById(int courseId)
        {
            Course aCourse = db.Courses.FirstOrDefault(m => m.Id == courseId);
            return Json(aCourse, JsonRequestBehavior.AllowGet);
        }

        // POST: /CourseAssign/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Include = "Id,DepartmentId,TeacherId,CreditTaken,CreditLeft,CourseID,Name,Credit")] CourseAssign courseassign)
        {
            if (ModelState.IsValid)
            {
                db.CourseAssigns.Add(courseassign);
                db.SaveChanges();
                ViewBag.Message = "Course Assigned Successful";

                //  return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "Id", "CourseCode", courseassign.CourseID);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DeptCode", courseassign.DepartmentId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "TeacherName", courseassign.TeacherId);
            return View(courseassign);
        }

        public JsonResult SaveCourseAssign(CourseAssign courseAssign)
        {
            var checkAssignedCoueses =
                db.CourseAssigns.Where(m => m.CourseID == courseAssign.CourseID && m.Course.CourseStatus == true)
                    .ToList();

            if (checkAssignedCoueses.Count > 0)
                return Json(false);

            else
            {
                db.CourseAssigns.Add(courseAssign);
                db.SaveChanges();

                var teacher = db.Teachers.FirstOrDefault(m => m.Id == courseAssign.TeacherId);

                if (teacher != null)
                {
                    teacher.CreditLeft = courseAssign.CreditLeft;
                    db.Teachers.AddOrUpdate(teacher);
                    db.SaveChanges();

                    var course = db.Courses.FirstOrDefault(m => m.Id == courseAssign.CourseID);

                    if (course != null)
                    {
                        course.CourseStatus = true;
                        course.CourseAssignTo = teacher.TeacherName;
                        db.Courses.AddOrUpdate(course);
                        db.SaveChanges();

                        return Json(true);
                    }
                    else
                    {
                        return Json(false);
                    }
                }
                else
                {
                    return Json(false);
                }
            }
        }

        // GET: /CourseAssign/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssign courseassign = db.CourseAssigns.Find(id);
            if (courseassign == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "Id", "CourseCode", courseassign.CourseID);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DeptCode", courseassign.DepartmentId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "TeacherName", courseassign.TeacherId);
            return View(courseassign);
        }

        // POST: /CourseAssign/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,DepartmentId,TeacherId,CreditTaken,CreditLeft,CourseID,Name,Credit")] CourseAssign courseassign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseassign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "Id", "CourseCode", courseassign.CourseID);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DeptCode", courseassign.DepartmentId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "TeacherName", courseassign.TeacherId);
            return View(courseassign);
        }

        // GET: /CourseAssign/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssign courseassign = db.CourseAssigns.Find(id);
            if (courseassign == null)
            {
                return HttpNotFound();
            }
            return View(courseassign);
        }

        // POST: /CourseAssign/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseAssign courseassign = db.CourseAssigns.Find(id);
            db.CourseAssigns.Remove(courseassign);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
