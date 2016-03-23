using HRISWebApplication.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HRISWebApplication.DAL
{
    public class DepartmentGateway
    {
        string connectionString = @"Server=.\SQLEXPRESS; Database=HRIS;Integrated Security=true;";

        public List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();

            SqlConnection dBConnection = new SqlConnection(connectionString);
            string getDepartmentQuery = "SELECT * FROM Departments";
            SqlCommand command = new SqlCommand(getDepartmentQuery, dBConnection);
            dBConnection.Open();
            SqlDataReader readData = command.ExecuteReader();

            while (readData.Read())
            {
                int id = (int)readData["ID"];
                string name = readData["Name"].ToString();
                Department aDepartment = new Department(id, name);

                departments.Add(aDepartment);
            }

            return departments;
        }
    }
}