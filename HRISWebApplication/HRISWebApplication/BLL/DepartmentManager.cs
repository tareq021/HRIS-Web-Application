using HRISWebApplication.DAL;
using HRISWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRISWebApplication.BLL
{
    public class DepartmentManager
    {
        public List<Department> GetAllDepartments()
        {
            DepartmentGateway gateway = new DepartmentGateway();

            List<Department> departments = gateway.GetDepartments();

            return departments;
        }
    }
}