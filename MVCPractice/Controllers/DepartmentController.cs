using MVCPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractice.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/

        public ActionResult Index()
        {
            EmployeeContext objEmployeeContext = new EmployeeContext();
            List<Department> lstDepartment = objEmployeeContext.Departments.ToList<Department>();
            return View(lstDepartment);
        }

    }
}
