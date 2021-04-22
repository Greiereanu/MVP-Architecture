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
    public partial class EmployeeView : Form, IEmployeeView
    {
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

        public TextBox name
        {
            get
            {
                return this.textBox1;
            }
        }

        public TextBox type
        {
            get
            {
                return this.textBox2;
            }
        }

        public TextBox species
        {
            get
            {
                return this.textBox3;
            }
        }

        public TextBox carnivorous
        {
            get
            {
                return this.textBox4;
            }
        }

        public TextBox zone
        {
            get
            {
                return this.textBox5;
            }
        }

        public EmployeeView()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            VisitorView mainPage = new VisitorView();
            mainPage.ShowDialog();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            EmployeePresenter ep = new EmployeePresenter(this);
            ep.deletePlant();
        }

        private void EmployeeView_Load(object sender, EventArgs e)
        {
            EmployeePresenter ep = new EmployeePresenter(this);
            ep.ShowInfo();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            EmployeePresenter ep = new EmployeePresenter(this);
            ep.addPlant();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            EmployeePresenter ep = new EmployeePresenter(this);
            ep.editPlant();

        }

        private void reportBtn_Click(object sender, EventArgs e)
        {
            EmployeePresenter ep = new EmployeePresenter(this);
            ep.generateReports();
        }
    }
}
