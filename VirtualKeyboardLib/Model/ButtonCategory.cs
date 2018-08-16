using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ButtonCategory 
    {
        public string ButtonCharacter { get; set; }
        public bool LPair { get; set; }
        public bool RPair { get; set; }

        public ButtonCategory(string ButtonCharacter, bool LPair, bool RPair)
        {
            this.ButtonCharacter = ButtonCharacter;
            this.LPair = LPair;
            this.RPair = RPair;
        }

    }
}
