using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Properties;

namespace BAL
{
    public class EmployeeBAL
    {
        public List<Employee> GetAllEmployees()
        {
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            return objEmployeeDAL.GetAllEmployees();
        }
        public object InsertEmployee(Employee objEmployee)
        {
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            return objEmployeeDAL.InsertEmployee(objEmployee);
        }
    }
}
