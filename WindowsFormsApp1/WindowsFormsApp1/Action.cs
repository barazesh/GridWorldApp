using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Action
    {
        public int NextState { get; set; }
        public int Reward { get; set; }

        public Action()
        {
            Reward = 0;
        }

    }
}
