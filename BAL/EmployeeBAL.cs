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
        #region GetAllEmployees
        public List<Employee> GetAllEmployees()
        {
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            return objEmployeeDAL.GetAllEmployees();
        }
        #endregion

        #region InsertEmployee
        public object InsertEmployee(Employee objEmployee)
        {
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            return objEmployeeDAL.InsertEmployee(objEmployee);
        }
        #endregion

        #region UpdateEmployee
        public object UpdateEmployee(Employee objEmployee)
        {
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            return objEmployeeDAL.UpdateEmployee(objEmployee);
        }
        #endregion
    }
}
