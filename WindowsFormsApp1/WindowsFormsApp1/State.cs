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

        public Action Up = new Action();
        public Action Down = new Action();
        public Action Right = new Action();
        public Action Left = new Action();

        public State()
        {
            _Value = 0;
        }

    }
}
