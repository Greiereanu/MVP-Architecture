using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Garden.Model;

namespace Garden.View
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            VisitorView returnPage = new VisitorView();
            returnPage.ShowDialog();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            EmployeePersistance ep = new EmployeePersistance();
            Employee emp = ep.findEmployee(this.accountText.Text);

            if(emp.getAccount() == "not" || emp.getPassword() != this.PasswordText.Text)
            {
                MessageBox.Show("Incorrect username or password");
            }
            else
            {
                if(emp.getRole() == "admin")
                {
                    this.Hide();
                    AdminView adminPage = new AdminView();
                    adminPage.ShowDialog();
                }
                else
                {
                    this.Hide();
                    EmployeeView employeePage = new EmployeeView();
                    employeePage.ShowDialog();
                }
            }

        }
    }
}
