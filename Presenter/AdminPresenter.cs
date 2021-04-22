using Garden.Model;
using Garden.View;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Garden.Presenter
{
    class AdminPresenter
    {
        IAdminView formTest;
        EmployeePersistance ep = new EmployeePersistance();
        public AdminPresenter(IAdminView view)
        {
            this.formTest = view;
        }

        public void ShowInfo()
        {
            List<Employee> result = ep.loadEmployees();
            foreach (Employee emp in result)
                this.formTest.table.Rows.Add(emp.getAccount(), emp.getPassword(), emp.getRole());
        }
        public void refreshInfo()
        {
            this.formTest.table.Rows.Clear();
            this.formTest.table.Refresh();
            this.ShowInfo();
        }
        public void addEmployee()
        {
            if(this.formTest.account.Text == "" || this.formTest.password.Text == "" || this.formTest.role.Text == "")
            {
                MessageBox.Show("You must enter data in all of those fields!");
            }
            else
            {
                Employee e = new Employee(this.formTest.role.Text, this.formTest.account.Text, this.formTest.password.Text);
                ep.saveEmployee(e);
                this.refreshInfo();
            }
        }

        public void deleteEmployee()
        {

            if(this.formTest.account.Text == "")
            {
                MessageBox.Show("In order to delete an employee, enter his account!");
            }
            else
            {
                Employee e = ep.findEmployee(this.formTest.account.Text);
                if (e.getAccount() == "not")
                {
                    MessageBox.Show("That users doesn't exist!");
                }
                else
                {
                    ep.deleteEmployee(e);
                    this.refreshInfo();
                }
            }
        }

        public void filterEmployees()
        {
            List<Employee> result = ep.filterEmployees(this.formTest.selection.Text);
            
            this.formTest.table.Rows.Clear();
            this.formTest.table.Refresh();
            foreach (Employee emp in result)
                this.formTest.table.Rows.Add(emp.getAccount(), emp.getPassword(), emp.getRole());
        }

        public void editEmployee()
        {
            List<Employee> result = ep.loadEmployees();
            Employee e = ep.findEmployee(this.formTest.account.Text);
            if(e.getAccount() == "not")
            {
                MessageBox.Show("That users doesn't exist!");
            }
            else
            {
                if(this.formTest.password.Text == "" || this.formTest.role.Text == "")
                {
                    MessageBox.Show("You must provide that user a password and a role!");
                }
                else
                {
                    Employee newEmployee = new Employee(this.formTest.role.Text, this.formTest.account.Text, this.formTest.password.Text);
                    ep.editEmployee(e, newEmployee);
                }
            }

            this.formTest.table.Rows.Clear();
            this.formTest.table.Refresh();
            List<Employee> after = ep.loadEmployees();
            foreach (Employee emp in after)
                this.formTest.table.Rows.Add(emp.getAccount(), emp.getPassword(), emp.getRole());
        }
    }

}
