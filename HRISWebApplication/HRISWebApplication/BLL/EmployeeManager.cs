using HRISWebApplication.DAL;
using HRISWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRISWebApplication.BLL
{
    public class EmployeeManager
    {
        EmployeeGateway gateway = new EmployeeGateway();
        public string saveEmployee(Employee aEmployee)
        {
            string message = "";
            if (!gateway.IsIdExists(aEmployee.ID))
            {
                int rowsEffected = gateway.InsertEmployee(aEmployee);
                if (rowsEffected > 0)
                {
                    message = "Saved Successfuly !!!";
                }
                else
                {
                    message = "Can not be saved";
                }
            }
            else
            {
                message = "ID is in Use. Please Assign New ID";
            }

            return message;
        }
        public Employee GetEmployeeById(string employeeId)
        {
            Employee aEmployee = new Employee();

            aEmployee = gateway.GetEmployeeById(employeeId);

            return aEmployee;
        }
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = gateway.GetAllEmployees();

            return employees;
        }

        internal string Update(Employee aEmployee, string newEmployeeId)
        {
            bool isUpdated = gateway.Update(aEmployee, newEmployeeId);
            string message = "Update Failed";
            if (isUpdated)
            {
                message = "Record Updated!";
            }

            return message;
        }

        internal string Delete(Employee aEmployee)
        {
            bool isDeleted = gateway.Delete(aEmployee);
            string message = "Delete Failed";
            if (isDeleted)
            {
                message = "Record Deleted!";
            }

            return message;
        }
    }
}