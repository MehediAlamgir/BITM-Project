using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityMS.Models;
using UniversityMS.Context;

namespace UniversityMS.Controllers
{
    public class CourseController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: /Course/
        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Department).Include(c => c.Semester);
            return View(courses.ToList());
        }

        // GET: /Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: /Course/Create
        public ActionResult Save()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DeptCode");
            ViewBag.SemesterId = new SelectList(db.Semesters, "Id", "SemesterName");
            return View();
        }

        // POST: /Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Include="Id,CourseCode,CourseName,CourseCredit,CourseDescription,DepartmentId,SemesterId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                ViewBag.Message = "Course Saved Successfully.";
                // return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DeptCode", course.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "Id", "SemesterName", course.SemesterId);
            return View(course);
        }

        public JsonResult IsUniqueCode(string CourseCode)
        {
            return Json(!db.Courses.Any(m => m.CourseCode == CourseCode), JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsUniqueName(string CourseName)
        {
            return Json(!db.Courses.Any(m => m.CourseName == CourseName), JsonRequestBehavior.AllowGet);
        }

        // GET: /Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DeptCode", course.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "Id", "SemesterName", course.SemesterId);
            return View(course);
        }

        // POST: /Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,CourseCode,CourseName,CourseCredit,CourseDescription,CourseAssignTo,CourseStatus,DepartmentId,SemesterId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DeptCode", course.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "Id", "SemesterName", course.SemesterId);
            return View(course);
        }

        // GET: /Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: /Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UnassignCourses()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult UnassignAllCourses(bool decision)
        {
            var courses = db.Courses.Where(m => m.CourseStatus == true).ToList();
            if (courses.Count == 0)
            {
                return Json(false);
            }
            else
            {
                foreach (var course in courses)
                {
                    course.CourseStatus = false;
                    course.CourseAssignTo = "";
                    db.Courses.AddOrUpdate(course);
                    db.SaveChanges();
                }
                return Json(true);

            }
        }
    }
}
