using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  CoreFunctions
{
    public static class KeyboardChecker
    {
       static string[] stringArray = { "1","2", "3", "4", "5", "6", "7", "8", "9", "0", "q","w"
                ,"e","r","t", "y", "u", "i", "o","p", "a", "s", "d", "f", "g", "h", "j","k", "l", "^", "z",
            "x", "c", "v", "b", "n", "m",",","."};



        public static KeyboardDetails VerifyIfTheresMissingChar(KeyboardDetails oData)
        {
            var dMissingChars = new KeyboardDetails();
            var oDataKeyArray = oData.Select(x => x.Key).ToArray();
            foreach (var item in stringArray)
            {
                int position = Array.IndexOf(oDataKeyArray, item);
                if (position == -1)
                {
                    dMissingChars.Add(item, null);
                }
            }
            return dMissingChars;
        }
    }
}
