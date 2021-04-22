using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Garden.Presenter;

namespace Garden.View
{
    public partial class AdminView : Form, IAdminView
    {
        public AdminView()
        {
            InitializeComponent();
        }
        
        public DataGridView table
        {
            get
            {
                return this.dataGridView1;
            }
            set
            {
                this.dataGridView1 = value;
            }
        }

        public ComboBox selection
        {
            get
            {
                return this.comboBox1;
            }
        }

        public TextBox account
        {
            get
            {
                return this.accountTxt;
            }
        }

        public TextBox password
        {
            get
            {
                return this.passwordTxt;
            }
        }

        public TextBox role
        {
            get
            {
                return this.roleTxt;
            }
        }

        private void formTest_Load(object sender, EventArgs e)
        {
            AdminPresenter fp = new AdminPresenter(this);
            fp.ShowInfo();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminPresenter fp = new AdminPresenter(this);
            fp.filterEmployees();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminPresenter fp = new AdminPresenter(this);
            fp.addEmployee();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminPresenter fp = new AdminPresenter(this);
            fp.deleteEmployee();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminPresenter fp = new AdminPresenter(this);
            fp.editEmployee();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            VisitorView mainPage = new VisitorView();
            mainPage.ShowDialog();
        }
    }
}
