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

        public ActionResult EmployeeDetails(int id)
        {
            //List<Employee> lstEmployee = new List<Employee>();
            //lstEmployee.Add(new Employee { Name="Nazeer", EmployeeID=1, City="Hyderabad", Gender="Male"});
            //lstEmployee.Add(new Employee { Name = "John", EmployeeID = 2, City = "Hyderabad", Gender = "Male" });
            //lstEmployee.Add(new Employee { Name = "Gulzar", EmployeeID = 3, City = "Hyderabad", Gender = "Female" });
            //Employee objEmployee = new Employee() { Name = "Gulzar", EmployeeID = 3, City = "Hyderabad", Gender = "Female" };
            EmployeeContext objEmployeeContext = new EmployeeContext();
            Employee objEmployee = objEmployeeContext.Employees.First(x => x.EmployeeID == id);

            return View(objEmployee);
        }
        public ActionResult Index()
        {
            EmployeeContext objEmployeeContext = new EmployeeContext();
            List<Employee> lstEmployee = objEmployeeContext.Employees.ToList<Employee>();
            return View(lstEmployee);
        }

    }
}
