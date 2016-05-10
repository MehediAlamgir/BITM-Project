using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityMS.Models;
using UniversityMS.Context;

namespace UniversityMS.Controllers
{
    public class StudentController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();
       

        // GET: /Student/
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Department);
            return View(students.ToList());
        }

        // GET: /Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: /Student/Create
        public ActionResult Register()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DeptCode");
            return View();
        }

        // POST: /Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Id,Name,Email,ContactNo,Date,Address,DepartmentId")] Student student)
        {
            if (ModelState.IsValid)
            {
                
                student.StudentRegNo = GetStudentRegNo(student);

                db.Students.Add(student);
                db.SaveChanges();
                ViewBag.Message = "Student Registered Successfully";
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DeptCode", student.DepartmentId);
            return View(student);
        }

        public string GetStudentRegNo(Student aStudent)
        {
            var cnt =
                db.Students.Count(m => (m.DepartmentId == aStudent.DepartmentId) && (m.Date.Year == aStudent.Date.Year)) +
                1;

            var aDepartment = db.Departments.FirstOrDefault(m => m.Id == aStudent.DepartmentId);

            string leadingZero = "";
            int length = 3 - cnt.ToString().Length;
            for (int i = 0; i < length; i++)
            {
                leadingZero += "0";
            }

            string studentRegNo = aDepartment.DeptCode + "-" + aStudent.Date.Year + "-"+leadingZero+cnt;
            return studentRegNo;
        }


        public JsonResult IsEmailExists(string Email)
        {
            return Json(!db.Students.Any(m => m.Email == Email), JsonRequestBehavior.AllowGet);
        }

        // GET: /Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DeptCode", student.DepartmentId);
            return View(student);
        }

        // POST: /Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Email,ContactNo,Date,Address,DepartmentId,StudentRegNo")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DeptCode", student.DepartmentId);
            return View(student);
        }

        // GET: /Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
