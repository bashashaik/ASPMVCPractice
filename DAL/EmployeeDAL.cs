﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Properties;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace DAL
{
    public class EmployeeDAL
    {
        private string strConnectionString = string.Empty;
        public EmployeeDAL()
        {
            strConnectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString.ToString();
        }
        public List<Employee> GetAllEmployees()
        {
            List<Employee> lstEmployee = new List<Employee>();
            SqlDataReader objSqlDataReader = null;
            Employee objEmployee = null;
            using (SqlConnection connection = new SqlConnection(strConnectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Connection = connection;
                    sqlCmd.CommandText = "uspGetAllEmployees";
                    connection.Open();
                    objSqlDataReader = sqlCmd.ExecuteReader();
                    while (objSqlDataReader.Read())
                    {
                        objEmployee = new Employee();
                        objEmployee.Id = Convert.ToInt32(objSqlDataReader["Id"]);
                        objEmployee.Name = objSqlDataReader["Name"].ToString();
                        objEmployee.Gender = objSqlDataReader["Gender"].ToString();
                        objEmployee.City = objSqlDataReader["City"].ToString();
                        objEmployee.DateOfBirth = Convert.ToDateTime(objSqlDataReader["DateOfBirth"]);
                        lstEmployee.Add(objEmployee);
                    }
                }
            }
            return lstEmployee;
        }
        public object InsertEmployee(Employee objEmployee)
        {
            int output = 0;
            using (SqlConnection connection = new SqlConnection(strConnectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = connection;
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.CommandText = "uspInsertEmployee";
                    sqlCmd.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar).Value = objEmployee.Name;
                    sqlCmd.Parameters.Add("@Gender", System.Data.SqlDbType.NVarChar).Value = objEmployee.Gender;
                    sqlCmd.Parameters.Add("@City", System.Data.SqlDbType.NVarChar).Value = objEmployee.City;
                    if (objEmployee.DateOfBirth > DateTime.MinValue)
                    {
                        sqlCmd.Parameters.Add("@DateOfBirth", System.Data.SqlDbType.NVarChar).Value = objEmployee.DateOfBirth;
                    }
                    else
                    {
                        sqlCmd.Parameters.Add("@DateOfBirth", System.Data.SqlDbType.NVarChar).Value = (object)DBNull.Value;
                    }
                    connection.Open();
                    output = sqlCmd.ExecuteNonQuery();

                }
            }
            return output;
        }
    }
}
