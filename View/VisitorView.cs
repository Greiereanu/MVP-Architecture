using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Garden.Model;
using Garden.Presenter;

namespace Garden.View
{
    public partial class VisitorView : Form, IVisitorView
    {
        public VisitorView()
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
                return this.filterCombo;
            }
        }

        public ComboBox charts
        {
            get
            {
                return this.statsCombo;
            }
        }

        public TextBox search
        {
            get
            {
                return this.searchTxt;
            }
        }

        public TextBox filter
        {
            get
            {
                return this.filterTxt;
            }
        }

        public Chart stats
        {
            get
            {
                return this.statistics;
            }
            set
            {
                this.statistics = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn loginPage = new LogIn();
            loginPage.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void VisitorView_Load(object sender, EventArgs e)
        {
            VisitorPresenter vp = new VisitorPresenter(this);
            vp.ShowInfo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VisitorPresenter vp = new VisitorPresenter(this);
            vp.findPlant();
        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            VisitorPresenter vp = new VisitorPresenter(this);
            vp.filterPlants();
        }

        private void statsBtn_Click(object sender, EventArgs e)
        {
            VisitorPresenter vp = new VisitorPresenter(this);
            vp.showStatistics();
        }

    }
}
