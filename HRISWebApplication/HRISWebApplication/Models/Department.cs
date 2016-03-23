using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRISWebApplication.Models
{
    public class Department
    {
        public Department(int id, string name)
        {
            DepartmentID = id;
            DepartmentName = name;
        }

        public string DepartmentName { get; set; }
        public int DepartmentID { get; set; }
    }
}