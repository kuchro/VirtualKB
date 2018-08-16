using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ButtonDetails
    {
        public int X { set; get; }
        public int Y { set; get; }
        public ButtonDetails()
        { }
        public ButtonDetails(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
