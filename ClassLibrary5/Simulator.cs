using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSimulator
{
    public class Simulator
    {
        public int state;

        public Simulator()
        {
            state = 1;
        }

        public void simulate()
        {
            Random randomS = new Random();
            state = randomS.Next(0, 15);
        }


    }
}
