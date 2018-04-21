using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class State
    {
        private double _Value;

        public double Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        Action Up = new Action();
        Action Down = new Action();
        Action Right = new Action();
        Action Left = new Action();

        public State()
        {
            _Value = 0;
        }

    }
}
