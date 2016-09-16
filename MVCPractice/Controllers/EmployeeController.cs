using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPractice.Models;
using BAL;


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
        public ActionResult GetAllEmployees()
        {
            List<Properties.Employee> lstEmployee = null;
            EmployeeBAL objEmployeeBAL = new EmployeeBAL();
            lstEmployee = objEmployeeBAL.GetAllEmployees();
            return View(lstEmployee);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Create(FormCollection objFormCollection)
        //{
        //    List<Properties.Employee> lstEmployee = new List<Properties.Employee>();
        //    Properties.Employee objEmployee = new Properties.Employee();
        //    //foreach(string strKey in objFormCollection)
        //    //{
        //    //    objEmployee = new Properties.Employee();
        //    //    Response.Write("Key = " + strKey + "  ");
        //    //    Response.Write("Value = " + objFormCollection[strKey]);
        //    //    Response.Write("<br/>");
        //    //}
        //    if (ModelState.IsValid)
        //    {
        //        objEmployee.Name = objFormCollection["Name"];
        //        objEmployee.Gender = objFormCollection["Gender"];
        //        objEmployee.City = objFormCollection["City"];
        //        objEmployee.DateOfBirth = Convert.ToDateTime(objFormCollection["DateOfBirth"]);
        //        EmployeeBAL objEmployeeBAL = new EmployeeBAL();
        //        objEmployeeBAL.InsertEmployee(objEmployee);
        //        return RedirectToAction("GetAllEmployees");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreateNewEmployee()
        {
            Properties.Employee objEmployee = new Properties.Employee();
            TryUpdateModel<Properties.Employee>(objEmployee);
            if (ModelState.IsValid)
            {
                EmployeeBAL objEmployeeBAL = new EmployeeBAL();
                objEmployeeBAL.InsertEmployee(objEmployee);
                return RedirectToAction("GetAllEmployees");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Properties.Employee objEmployee = null;
            List<Properties.Employee> lstEmployee = null;
            EmployeeBAL objEmployeeBAL = new EmployeeBAL();
            lstEmployee = objEmployeeBAL.GetAllEmployees();
            objEmployee = lstEmployee.First(x => x.Id == id);
            if (objEmployee != null)
            {
                return View(objEmployee);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            EmployeeBAL objEmployeeBAL = null;
            Properties.Employee objEmployee = null;
            List<Properties.Employee> lstEmployee = null;
            if (ModelState.IsValid)
            {
                try
                {
                    objEmployeeBAL = new EmployeeBAL();
                    lstEmployee = objEmployeeBAL.GetAllEmployees();
                    objEmployee = lstEmployee.First(X => X.Id == id);
                    TryUpdateModel(objEmployee, new string[] { "Gender", "City", "DateOfBirth" });
                    objEmployeeBAL.UpdateEmployee(objEmployee);
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    objEmployeeBAL = null;
                }
                return RedirectToAction("GetAllEmployees");
            }
            else
            {
                return View();
            }
        }
        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit_Post([Bind(Exclude="Name")] Properties.Employee objEmployee)
        //{
        //    try
        //    {
        //        EmployeeBAL objEmployeeBAL = new EmployeeBAL();
        //        objEmployee.Name = objEmployeeBAL.GetAllEmployees().FirstOrDefault(X => X.Id == objEmployee.Id).Name;
        //        if(ModelState.IsValid)
        //        {
        //            objEmployeeBAL.UpdateEmployee(objEmployee);
        //            return RedirectToAction("GetAllEmployees");
        //        }
        //        else
        //        {
        //            return View(objEmployee);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return View(objEmployee);
        //    }
        //    finally
        //    {
        //    }
        //}

        #region Delete
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            EmployeeBAL objEmployeeBAL = new EmployeeBAL();
            Properties.Employee objEmployee = null;
            try
            {
                objEmployee = new Properties.Employee();
                TryUpdateModel(objEmployee);
                objEmployeeBAL.DeleteEmployee(objEmployee);
                return RedirectToAction("GetAllEmployees");
            }
            catch
            {
                return View();
            }
            finally
            {
                objEmployeeBAL = null;
            }
        }
        #endregion

        #region DatePicker
        public ActionResult DatePicker()
        {
            return View();
        }
        #endregion
    }
}
