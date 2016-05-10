using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMS.BLL;
using UniversityMS.Models;

namespace UniversityMS.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        //
        // GET: /Department/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Save()
        {
            return View();
        } 
        
        [HttpPost]
        public ActionResult Save(Department aDepartment)
        {
            string message = "";
            
            message = departmentManager.SaveDepartment(aDepartment);

            ViewBag.Message = message;

            return View();
        }
        public ActionResult Show()
        {

            List<Department> departments = departmentManager.GetAllDepartment();
            ViewBag.DepartmentList = departments;
            return View();
        }

        public JsonResult IsDeptCodeExists(string DeptCode)
        {
            bool isDeptCodeExists = departmentManager.IsDepartmentCodeExist(DeptCode);

            if (isDeptCodeExists)
                return Json(false, JsonRequestBehavior.AllowGet);
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
               
            }
        }

        public JsonResult IsDeptNameExists(string DeptName)
        {
            bool isDeptNameExists = departmentManager.IsDepartmentNameExist(DeptName);

            if (isDeptNameExists)
                return Json(false, JsonRequestBehavior.AllowGet);
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
               
            }
        }
	}
}