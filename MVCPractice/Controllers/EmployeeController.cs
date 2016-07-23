using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPractice.Models;

namespace MVCPractice.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        public ActionResult EmployeeDetails(int id = 0)
        {
            //List<Employee> lstEmployee = new List<Employee>();
            //lstEmployee.Add(new Employee { Name="Nazeer", EmployeeID=1, City="Hyderabad", Gender="Male"});
            //lstEmployee.Add(new Employee { Name = "John", EmployeeID = 2, City = "Hyderabad", Gender = "Male" });
            //lstEmployee.Add(new Employee { Name = "Gulzar", EmployeeID = 3, City = "Hyderabad", Gender = "Female" });
            //Employee objEmployee = new Employee() { Name = "Gulzar", EmployeeID = 3, City = "Hyderabad", Gender = "Female" };
            EmployeeContext objEmployeeContext = null;
            Employee objEmployee = null;
            objEmployeeContext = new EmployeeContext();
            if (id > 0)
            {
                objEmployee = objEmployeeContext.Employees.First(x => x.EmployeeID == id);
                return View(objEmployee);
            }
            else
            {
                return Index();
            }
        }
        public ActionResult Index(int intDepartmentId = 0)
        {
            List<Employee> lstEmployee = null;
            EmployeeContext objEmployeeContext = new EmployeeContext();
            if (intDepartmentId > 0)
            {
                lstEmployee = objEmployeeContext.Employees.Where(x => x.DepartmentId == intDepartmentId).ToList();
            }
            else
            {
                lstEmployee = objEmployeeContext.Employees.ToList<Employee>();
            }
            return View(lstEmployee);
        }

    }
}
