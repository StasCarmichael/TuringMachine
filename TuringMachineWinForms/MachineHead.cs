using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachineWinForms
{
    enum eDirection { L = -1, N = 0, R = 1 };

    class MachineHead
    {
        public char letter { get; set; }
        public int direction { get; set; }
        public int state { get; set; }


        public MachineHead(string str)
        {
            try
            {
                string[] elementArray = str.Split(',');


                letter = Convert.ToChar(elementArray[0]);

                switch (Convert.ToChar(elementArray[1]))
                {
                    case 'L':
                        direction = (int)eDirection.L; break;

                    case 'N':
                        direction = (int)eDirection.N; break;

                    case 'R':
                        direction = (int)eDirection.R; break;


                    default:
                        new Exception("System Error"); break;
                }

                state = Convert.ToInt32(elementArray[2]);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Convert Error" + ex.Message);
            }
        }
    }
}
