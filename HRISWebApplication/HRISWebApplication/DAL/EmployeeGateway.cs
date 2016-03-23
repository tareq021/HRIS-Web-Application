using HRISWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HRISWebApplication.DAL
{
    public class EmployeeGateway
    {
        string connectionString = @"Server=.\SQLEXPRESS; Database=HRIS;Integrated Security=true;";

        public int InsertEmployee(Employee aEmployee)
        {
            SqlConnection dBConnection = new SqlConnection(connectionString);
            string insertEmployeeQuery = "INSERT INTO Employees (Name, EmployeeID, DepartmentId) VALUES ('" + aEmployee.Name+"','"+aEmployee.ID+"','"+aEmployee.DepartmentID+"')";
            dBConnection.Open();
            SqlCommand command = new SqlCommand(insertEmployeeQuery, dBConnection);
            int rowsEffected = command.ExecuteNonQuery();
            dBConnection.Close();

            return rowsEffected;            
        }

        public int GetEmployeeDbID(string iD)
        {
            SqlConnection dBConnection = new SqlConnection(connectionString);
            string searchEmployeeQuery = "SELECT * FROM Employees WHERE EmployeeID = '" + iD + "'";
            dBConnection.Open();
            SqlCommand command = new SqlCommand(searchEmployeeQuery, dBConnection);
            SqlDataReader reader = command.ExecuteReader();

            int dBId = 0;
            if (reader.Read())
            {
                dBId = (int)reader["Id"];
            }

            dBConnection.Close();

            return dBId;
        }

        public bool IsIdExists(string iD)
        {
            bool isIdExists = false;

            SqlConnection dBConnection = new SqlConnection(connectionString);
            string searchEmployeeQuery = "SELECT * FROM Employees WHERE EmployeeID = '" + iD + "'";
            dBConnection.Open();
            SqlCommand command = new SqlCommand(searchEmployeeQuery, dBConnection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                isIdExists = true;
            }

            dBConnection.Close();

            return isIdExists;
        }

        internal bool Delete(Employee aEmployee)
        {
            int rowsEffected = 0;
            string deleteEmployeeQuery = "";

            if (IsIdExists(aEmployee.ID) == false)
            {
                return false;
            }
            else if (IsIdExists(aEmployee.ID) == true)
            {
                deleteEmployeeQuery = "DELETE FROM Employees WHERE EmployeeID = '" + aEmployee.ID + "'";
            }
            
            SqlConnection dBConnection = new SqlConnection(connectionString);

            dBConnection.Open();
            SqlCommand command = new SqlCommand(deleteEmployeeQuery, dBConnection);
            rowsEffected = command.ExecuteNonQuery();
            dBConnection.Close();

            return rowsEffected > 0;
        }

        internal bool Update(Employee aEmployee, string newEmployeeID)
        {
            int rowsEffected = 0;
            string updateEmployeeQuery = "";
            
            if (IsIdExists(newEmployeeID) == false)
            {
                updateEmployeeQuery = "UPDATE Employees SET Name = '" + aEmployee.Name + "', DepartmentId = '" + aEmployee.DepartmentID + "', EmployeeID = '" + newEmployeeID + "' WHERE EmployeeID ='" + aEmployee.ID + "'";
            }
            else if (IsIdExists(newEmployeeID) == true && newEmployeeID.Equals(aEmployee.ID))
            {
                updateEmployeeQuery = "UPDATE Employees SET Name = '" + aEmployee.Name + "', DepartmentId = '" + aEmployee.DepartmentID + "' WHERE EmployeeID ='" + newEmployeeID + "'";
            }
            else if(IsIdExists(newEmployeeID) == true && !newEmployeeID.Equals(aEmployee.ID))
            {
                return false;
            }
            
            SqlConnection dBConnection = new SqlConnection(connectionString);

            dBConnection.Open();
            SqlCommand command = new SqlCommand(updateEmployeeQuery, dBConnection);
            rowsEffected = command.ExecuteNonQuery();
            dBConnection.Close();

            return rowsEffected>0;
        }

        internal Employee GetEmployeeById(string employeeId)
        {
            SqlConnection dBConnection = new SqlConnection(connectionString);
            string searchEmployeeQuery = "SELECT * FROM Employees WHERE EmployeeID = '" + employeeId + "'";
            dBConnection.Open();
            SqlCommand command = new SqlCommand(searchEmployeeQuery, dBConnection);
            SqlDataReader reader = command.ExecuteReader();

            Employee aEmployee = new Employee();

            while (reader.Read())
            {
                string id = reader["EmployeeID"].ToString();
                string name = reader["Name"].ToString();
                int departmentId = (int)reader["DepartmentId"];
              
                aEmployee.DepartmentID = departmentId;
                aEmployee.ID = id;
                aEmployee.Name = name;                     
            }

            dBConnection.Close();

            return aEmployee;
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List <Employee>();

            SqlConnection dBConnection = new SqlConnection(connectionString);
            string getDepartmentQuery = "SELECT * FROM Employees";
            SqlCommand command = new SqlCommand(getDepartmentQuery, dBConnection);
            dBConnection.Open();
            SqlDataReader readData = command.ExecuteReader();

            while (readData.Read())
            {
                string id = readData["EmployeeID"].ToString();
                string name = readData["Name"].ToString();
                int departmentId = (int)readData["DepartmentId"];
              
                Employee aEmployee = new Employee();
                aEmployee.DepartmentID = departmentId;
                aEmployee.ID = id;
                aEmployee.Name = name;
           
                employees.Add(aEmployee);
            }

            return employees;
        }
    }
}