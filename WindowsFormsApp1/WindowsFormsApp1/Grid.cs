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

        public void Initiate()
        {
            Array.Resize(ref States, Dim1 * Dim2);
            for (int i = 0; i < States.Length; i++)
            {
                //right-left moves
                if (i % Dim2 == 0)
                {
                    States[i].Left.NextState = i;
                    States[i].Left.Reward = -1;
                    States[i].Right.NextState = i + 1;
                    States[i].Right.Reward = 0;
                }
                else
                {
                    if (i % Dim2 == Dim2 - 1)
                    {
                        States[i].Left.NextState = i - 1;
                        States[i].Left.Reward = 0;
                        States[i].Right.NextState = i;
                        States[i].Right.Reward = -1;
                    }
                    else
                    {
                        States[i].Left.NextState = i - 1;
                        States[i].Left.Reward = 0;
                        States[i].Right.NextState = i + 1;
                        States[i].Right.Reward = 0;
                    }
                }


                //up-down moves
                if (i / Dim2 == 0)
                {
                    States[i].Down.NextState = i;
                    States[i].Down.Reward = -1;
                    States[i].Up.NextState = i + Dim2;
                    States[i].Up.Reward = 0;
                }
                else
                {
                    if (i / Dim2 == Dim1 - 1)
                    {
                        States[i].Down.NextState = i - Dim2;
                        States[i].Down.Reward = 0;
                        States[i].Up.NextState = i;
                        States[i].Up.Reward = -1;
                    }
                    else
                    {
                        States[i].Left.NextState = i - Dim2;
                        States[i].Left.Reward = 0;
                        States[i].Right.NextState = i + Dim2;
                        States[i].Right.Reward = 0;
                    }
                }


                //special cases
                if (i == 21)
                {
                    States[i].Down.NextState = 1;
                    States[i].Right.NextState = 1;
                    States[i].Left.NextState = 1;

                    States[i].Down.Reward = 10;
                    States[i].Right.Reward = 10;
                    States[i].Left.Reward = 10;

                }

                if (i == 23)
                {
                    States[i].Down.NextState = 13;
                    States[i].Right.NextState = 13;
                    States[i].Left.NextState = 13;

                    States[i].Down.Reward = 5;
                    States[i].Right.Reward = 5;
                    States[i].Left.Reward = 5;
                }
            }
        }

        public Grid(int d1, int d2)
        {
            Dim1 = d1;
            Dim2 = d2;
        }
    }
}
