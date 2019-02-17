using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linq
{
    public partial class Form1 : Form
    {

        EmpDBDataContext de;
        bool flag = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            de = new EmpDBDataContext();
            dataGridView1.DataSource = from E in de.Emps orderby E.Sal select E;

            //form <alias> in <de.Emps/ Table>[<clauses>] select <alias>

            //where ;
            //groupBy
            //orderBy


            var table = from E in de.Emps select E;

            var tab = from E in de.Emps select new { E.Job };
            comboBox1.DataSource = tab.Distinct();
            comboBox1.DisplayMember = "Job";
            comboBox1.SelectedIndex = -1;
            flag = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == true)
            dataGridView1.DataSource = from E in de.Emps where E.Job == comboBox1.Text select E;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridView1.DataSource = from E in de.Emps where E.Job.Contains(comboBox1.Text) select E;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = from E in de.Emps orderby E.Sal select E;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = from E in de.Emps orderby E.Ename descending select E;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = from E in de.Emps group E by E.Deptno into G select new { Deptno=G.Key, Empount=G.Count() };
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = from E in de.Emps select new { E.Ename, E.Sal, E.HireDate, E.Deptno };
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = from E in de.Emps group E by E.Job into G select new { Job=G.Key, JobCOunt =G.Count() };
        }
    }
}
