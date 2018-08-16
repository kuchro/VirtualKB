using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Duet : Tuple<bool, bool>
    {
        public Duet(bool item1, bool item2) : base(item1, item2)
        {
        }
    }

    public class DuetStr : Tuple<string, string>
    {
        public DuetStr(string left, string right) : base(left, right)
        {
        }
    }
}
