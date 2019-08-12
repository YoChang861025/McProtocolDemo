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

        public string stationID;
        public string ValueName;
        public int Value;
        public int ValueFormat;
        public string Type;

        public SV()
        {
            stationID = "station1";
            ValueName = "";
            Value = 0;
            ValueFormat = 0;
            Type = "";
    }

        public void getVolue()
        {
            Random randomV = new Random();
            int V = randomV.Next(0, 5);
            if (V == 0)
            {
                stationID = "station1";
                ValueName = "Temperature";
                Random randomT = new Random();
                int T = randomT.Next(300000, 400000);
                Value = T;
                ValueFormat = 4;
                Type = "℃";
            }
            else if (V == 1)
            {
                stationID = "station1";
                ValueName = "Air pressure";
                Random randomA = new Random();
                int A = randomA.Next(30000, 35000);
                Value = A;
                ValueFormat = 2;
                Type = "pa";
            }
            else if (V == 2)
            {
                stationID = "station1";
                ValueName = "rotationX";
                Random randomX = new Random();
                int X = randomX.Next(0, 901);
                Value = X;
                ValueFormat = 1;
                Type = "degree";
            }
            else if (V == 3)
            {
                stationID = "station1";
                ValueName = "rotationY";
                Random randomY = new Random();
                int Y = randomY.Next(0, 901);
                Value = Y;
                ValueFormat = 1;
                Type = "degree";
            }
            else if (V == 4)
            {
                stationID = "station1";
                ValueName = "rotationZ";
                Random randomZ = new Random();
                int Z = randomZ.Next(0, 901);
                Value = Z;
                ValueFormat = 1;
                Type = "degree";
            }
        }
        
        
    }
}
