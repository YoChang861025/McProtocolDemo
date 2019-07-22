using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ClassLibrary5
{
    class Buffer
    {
        public DataTable Table = new DataTable("buffer");

        public void Init(string input)
        {
            Table.Columns.Add(input, typeof(string));
        }

        public void Add(string temperture, string pa, string rotationX, string rotationY, string rotationZ)
        {
            DataRow dr = Table.NewRow();
            dr["temperture"] = temperture;
            dr["pa"] = pa;
            dr["rotationX"] = rotationX;
            dr["rotationY"] = rotationY;
            dr["rotationZ"] = rotationZ;
        }
    }
}
