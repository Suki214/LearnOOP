using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL.Interface;

namespace DAL.Employee
{
    public class EmployeeDAL : IDAL
    {
        private SqlConnection _connection = null;

        #region IDAL Members

        public DataTable GetAll()
        {
            DataTable employees = new DataTable();
            using (_connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * FROM EMPLOYEES";
                command.CommandType = CommandType.Text;
                command.Connection = _connection;
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                employees.Load(reader);
                _connection.Close();
            }

            return employees;
        }

        public DataTable GetById(string ID)
        {
            DataTable employees = new DataTable();
            using (_connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * FROM EMPLOYEES WHERE EmployeeID = @EmployeeID";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SqlParameter("@EmployeeID", ID));
                command.Connection = _connection;
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                employees.Load(reader);
                _connection.Close();
            }

            return employees;
        }

        public bool SaveOrUpdate(DataTable entity)
        {
            return true;
        }

        #endregion
    }
}
