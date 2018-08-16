using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class KeyboardDetails : Dictionary<string, ButtonDetails>
    {
        public new void Add(string DicKey, ButtonDetails oButtonDetails)
        {
            base.Add(DicKey, oButtonDetails);
        }
    }
}

