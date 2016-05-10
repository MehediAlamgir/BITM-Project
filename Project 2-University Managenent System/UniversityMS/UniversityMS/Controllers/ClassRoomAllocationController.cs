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
    public class ClassRoomAllocationController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: /ClassRoomAllocation/
        public ActionResult Index()
        {
           // var classroomallocations = db.ClassRoomAllocations.Include(c => c.Course).Include(c => c.Day).Include(c => c.Department).Include(c => c.Room);

            ViewBag.departments = db.Departments.ToList();
            return View();
        }

        //public JsonResult GetClassScheduleInfo(int deptId)
        //{
            
        //}

        // GET: /ClassRoomAllocation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassRoomAllocation classroomallocation = db.ClassRoomAllocations.Find(id);
            if (classroomallocation == null)
            {
                return HttpNotFound();
            }
            return View(classroomallocation);
        }

        // GET: /ClassRoomAllocation/Create
        public ActionResult Create()
        {
            //ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseCode");
            //ViewBag.DayId = new SelectList(db.Days, "Id", "Name");
            //ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DeptCode");
            //ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Name");

            ViewBag.courses = db.Courses.Where(s => s.CourseStatus == true).ToList();
            ViewBag.departments = db.Departments.ToList();
            ViewBag.Rooms = db.Rooms.ToList();
            ViewBag.Days = db.Days.ToList();

            return View();
        }

        // POST: /ClassRoomAllocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,DepartmentId,CourseId,RoomId,DayId,StartTime,EndTime,RoomStatus")] ClassRoomAllocation classroomallocation)
        {
            if (ModelState.IsValid)
            {
                db.ClassRoomAllocations.Add(classroomallocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseCode", classroomallocation.CourseId);
            ViewBag.DayId = new SelectList(db.Days, "Id", "Name", classroomallocation.DayId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DeptCode", classroomallocation.DepartmentId);
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Name", classroomallocation.RoomId);
            return View(classroomallocation);
        }

        public JsonResult SaveRoomSchedule(ClassRoomAllocation classRoomAllocation)
        {
            var scheduleList = db.ClassRoomAllocations.Where(m => m.RoomId == classRoomAllocation.RoomId && m.DayId == classRoomAllocation.DayId && m.RoomStatus == "Allocated").ToList();
            if (scheduleList.Count == 0)
            {
                classRoomAllocation.RoomStatus = "Allocated";
                db.ClassRoomAllocations.Add(classRoomAllocation);
                db.SaveChanges();
                return Json(true);
            }
            else
            {
                bool status = false;
                foreach (var allocation in scheduleList)
                {
                    if ((classRoomAllocation.StartTime >= allocation.StartTime && classRoomAllocation.StartTime < allocation.EndTime)
                         || (classRoomAllocation.EndTime > allocation.StartTime && classRoomAllocation.EndTime <= allocation.EndTime) && classRoomAllocation.RoomStatus == "Allocated")
                    {
                        status = true;
                    }
                }
                if (status == false)
                {
                    classRoomAllocation.RoomStatus = "Allocated";
                    db.ClassRoomAllocations.Add(classRoomAllocation);
                    db.SaveChanges();
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }

        }


        public JsonResult GetCoursesByDeptId(int deptId)
        {
            var courses = db.Courses.Where(m => m.DepartmentId == deptId).ToList();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        // GET: /ClassRoomAllocation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassRoomAllocation classroomallocation = db.ClassRoomAllocations.Find(id);
            if (classroomallocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseCode", classroomallocation.CourseId);
            ViewBag.DayId = new SelectList(db.Days, "Id", "Name", classroomallocation.DayId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DeptCode", classroomallocation.DepartmentId);
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Name", classroomallocation.RoomId);
            return View(classroomallocation);
        }

        // POST: /ClassRoomAllocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,DepartmentId,CourseId,RoomId,DayId,StartTime,EndTime,RoomStatus")] ClassRoomAllocation classroomallocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classroomallocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseCode", classroomallocation.CourseId);
            ViewBag.DayId = new SelectList(db.Days, "Id", "Name", classroomallocation.DayId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DeptCode", classroomallocation.DepartmentId);
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Name", classroomallocation.RoomId);
            return View(classroomallocation);
        }

        // GET: /ClassRoomAllocation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassRoomAllocation classroomallocation = db.ClassRoomAllocations.Find(id);
            if (classroomallocation == null)
            {
                return HttpNotFound();
            }
            return View(classroomallocation);
        }

        // POST: /ClassRoomAllocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassRoomAllocation classroomallocation = db.ClassRoomAllocations.Find(id);
            db.ClassRoomAllocations.Remove(classroomallocation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UnallocatedClassRoom()
        {
            return View();
        }

        public JsonResult UnAllocateAllRooms(bool decision)
        {
            var roomStatus = db.ClassRoomAllocations.Where(m => m.RoomStatus == "Allocated").ToList();
            if (roomStatus.Count == 0)
            {
                return Json(false);
            }
            else
            {
                foreach (var room in roomStatus)
                {
                    room.RoomStatus = "";
                    db.ClassRoomAllocations.AddOrUpdate(room);
                    db.SaveChanges();

                }
                return Json(true);
            }
           
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
