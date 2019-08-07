using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSimulator
{
    public class SV
    {
        //溫度,氣壓,軸

        public double temperatue;
        public double pa;
        public double rotationX;
        public double rotationY;
        public double rotationZ;
        public double rotationA;
        public double rotationB;
        public double rotationC;

        public SV()
        {
            temperatue = 0;
            pa = 0;
            rotationX = 0;
            rotationY = 0;
            rotationZ = 0;
            rotationA = 0;
            rotationB = 0;
            rotationC = 0;
    }

        public void getVolue()
        {
            Random randomT = new Random();
            temperatue = randomT.Next(30, 40);
            Random randomP = new Random();
            pa = 300 + randomP.Next(1, 50);
            Random randomR = new Random();
            rotationX = randomR.Next(0, 100);
            rotationY = randomR.Next(0, 100);
            rotationZ = randomR.Next(0, 100);
            rotationA = randomR.Next(0, 100);
            rotationB = randomR.Next(0, 100);
            rotationC = randomR.Next(0, 100);
        }
        
        
    }
}
