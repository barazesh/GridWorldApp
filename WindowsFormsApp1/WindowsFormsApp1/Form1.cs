using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Grid mygrid = new Grid(5, 5);
            mygrid.Initiate();
            mygrid.ComputeStateValues(0.9f, 0.0001f);
            timer.Stop();
            var ts = timer.ElapsedMilliseconds;
            txtResult.Text = mygrid.ToString();
            txtTime.Text = ts.ToString();

            





        }

        private void gridDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
