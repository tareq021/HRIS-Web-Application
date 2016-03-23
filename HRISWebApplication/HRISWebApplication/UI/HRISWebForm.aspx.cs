using HRISWebApplication.BLL;
using HRISWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRISWebApplication
{
    public partial class HRISWebForm : System.Web.UI.Page
    {
        DepartmentManager departmentManager = new DepartmentManager();
        EmployeeManager employeeManger = new EmployeeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    string employeeId = Request.QueryString["id"];

                    Employee aEmployee = employeeManger.GetEmployeeById(employeeId);

                    if (aEmployee != null)
                    {
                        employeeNameTextBox.Text = aEmployee.Name;
                        employeeIdTextBox.Text = aEmployee.ID;
                        departmentDropDownList.SelectedValue = aEmployee.DepartmentID.ToString();
                        saveButton.Text = "Update";
                    }
                }

                List<Department> departments = departmentManager.GetAllDepartments();

                departmentDropDownList.DataSource = departments;
                departmentDropDownList.DataTextField = "DepartmentName";
                departmentDropDownList.DataValueField = "DepartmentID";
                departmentDropDownList.DataBind();
            }
        }        
        protected void saveButton_Click(object sender, EventArgs e)
        {            
            Employee aEmployee = new Employee();
            aEmployee.Name = employeeNameTextBox.Text;
            aEmployee.ID = employeeIdTextBox.Text;
            aEmployee.DepartmentID = Convert.ToInt32(departmentDropDownList.SelectedValue);
            ReportLabel.Text = "";
            if (saveButton.Text != "Update")
            {
                ReportLabel.Text = employeeManger.saveEmployee(aEmployee);
            }
            else
            {
                string employeeId = Request.QueryString["id"];
                aEmployee.ID = employeeId;
                ReportLabel.Text = employeeManger.Update(aEmployee, employeeIdTextBox.Text);
                saveButton.Text = "Save";
            }
        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            List<Employee> employees = employeeManger.GetAllEmployees();

            displayGridView.DataSource = employees;
            displayGridView.DataBind();
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            Employee aEmployee = new Employee();
            string employeeId = Request.QueryString["id"];
            aEmployee.ID = employeeId;
            ReportLabel.Text = employeeManger.Delete(aEmployee);
        }
    }
}