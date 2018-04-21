using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Grid
    {
        public State[] States = new State[2];
        private int Dim1;
        private int Dim2;

        public Grid(int d1, int d2)
        {
            Dim1 = d1;
            Dim2 = d2;
        }
    }
}
