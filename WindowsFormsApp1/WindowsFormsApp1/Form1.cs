using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Grid mygrid = new Grid(5, 5);
            mygrid.Initiate();
            mygrid.ComputeStateValues(0.9f, 1f);
            textBox1.Text = Convert.ToString(mygrid.States[1].Value);





        }
    }
}
