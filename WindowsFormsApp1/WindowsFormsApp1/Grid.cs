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
                States[i] = new State();
                //right-left moves
                if (i % Dim2 == 0)//left edge
                {
                    States[i].Left.NextState = i;
                    States[i].Left.Reward = -1;
                    States[i].Right.NextState = i + 1;
                    States[i].Right.Reward = 0;
                }
                else if (i % Dim2 == Dim2 - 1)//right edge
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


                //up-down moves
                if (i / Dim2 == 0)//lower edge
                {
                    States[i].Down.NextState = i;
                    States[i].Down.Reward = -1;
                    States[i].Up.NextState = i + Dim2;
                    States[i].Up.Reward = 0;
                }
                else if (i / Dim2 == Dim1 - 1)//upper edge
                {
                    States[i].Down.NextState = i - Dim2;
                    States[i].Down.Reward = 0;
                    States[i].Up.NextState = i;
                    States[i].Up.Reward = -1;
                }
                else
                {
                    States[i].Down.NextState = i - Dim2;
                    States[i].Down.Reward = 0;
                    States[i].Up.NextState = i + Dim2;
                    States[i].Up.Reward = 0;

                }



                //special cases
                if (i == 21)
                {
                    States[i].Up.NextState = 1;
                    States[i].Down.NextState = 1;
                    States[i].Right.NextState = 1;
                    States[i].Left.NextState = 1;
                    States[i].Up.Reward = 10;
                    States[i].Down.Reward = 10;
                    States[i].Right.Reward = 10;
                    States[i].Left.Reward = 10;

                }

                if (i == 23)
                {
                    States[i].Up.NextState = 13;
                    States[i].Down.NextState = 13;
                    States[i].Right.NextState = 13;
                    States[i].Left.NextState = 13;
                    States[i].Up.Reward = 5;
                    States[i].Down.Reward = 5;
                    States[i].Right.Reward = 5;
                    States[i].Left.Reward = 5;
                }
            }
        }

        public int ComputeStateValues(float gamma, float eps, string mode)
        {
            int itr = 0;
            double variance = 10;
            while (variance > eps)
            {
                variance = 0;
                for (int i = 0; i < States.Length; i++)
                {
                    switch (mode)
                    {
                        case ("currentpolicy"):
                            
                            double newvalue = ((States[i].Up.Reward + gamma * States[States[i].Up.NextState].Value) +
                                (States[i].Down.Reward + gamma * States[States[i].Down.NextState].Value) +
                                (States[i].Right.Reward + gamma * States[States[i].Right.NextState].Value) +
                                (States[i].Left.Reward + gamma * States[States[i].Left.NextState].Value)) / 4;
                            if (Math.Abs(newvalue - States[i].Value) > variance)
                            {
                                variance = Math.Abs(newvalue - States[i].Value);
                            }
                            States[i].Value = newvalue;
                            break;
                        case ("optimal"):
                            double newval= Math.Max((States[i].Up.Reward + gamma * States[States[i].Up.NextState].Value),
                                Math.Max((States[i].Down.Reward + gamma * States[States[i].Down.NextState].Value),
                                Math.Max((States[i].Right.Reward + gamma * States[States[i].Right.NextState].Value),
                                (States[i].Left.Reward + gamma * States[States[i].Left.NextState].Value))));
                            if (Math.Abs(newval - States[i].Value) > variance)
                            {
                                variance = Math.Abs(newval - States[i].Value);
                            }
                            States[i].Value = newval;
                            
                            break;

                        default:
                            break;
                    }
                }
                itr++;
                
            }
            return itr;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = Dim1 - 1; i >= 0; i--)
            {
                for (int j = 0; j < Dim2; j++)
                {
                    int index = i * Dim2 + j;

                    if (j == Dim2 - 1)
                    {
                        sb.AppendLine(States[index].Value.ToString("F2"));
                    }
                    else
                    {
                        sb.Append(States[index].Value.ToString("F2") + ",   ");

                    }
                }
            }
            return sb.ToString();
        }

        public Grid(int d1, int d2)
        {
            Dim1 = d1;
            Dim2 = d2;
        }
    }
}
