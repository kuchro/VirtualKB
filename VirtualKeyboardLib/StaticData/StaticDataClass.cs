using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VStaticData
{
    public static class StaticDataClass
    {
        public static List<ButtonCategory> ButtonCategories = new List<ButtonCategory>()
        {
            new ButtonCategory("1",false,true),
            new ButtonCategory("2",true,true),
            new ButtonCategory("3" ,true,true),
            new ButtonCategory("4"  ,true,true),
            new ButtonCategory("5"  ,true,true),
            new ButtonCategory("6"     ,true,true),
            new ButtonCategory("7"     ,true,true),
            new ButtonCategory("8"     ,true,true),
            new ButtonCategory("9"     ,true,true),
            new ButtonCategory("0"     ,true,false),
            new ButtonCategory("q"     ,false,true),
            new ButtonCategory("w"     ,true,true),
            new ButtonCategory("e"     ,true,true),
            new ButtonCategory("r"     ,true,true),
            new ButtonCategory("t"     ,true,true),
            new ButtonCategory("y"     ,true,true),
            new ButtonCategory("u"     ,true,true),
            new ButtonCategory("i"     ,true,true),
            new ButtonCategory("o"     ,true,true),
            new ButtonCategory("p"     ,true,false),
            new ButtonCategory("a"     ,false,true),
            new ButtonCategory("s"     ,true,true),
            new ButtonCategory("d"     ,true,true),
            new ButtonCategory("f"     ,true,true),
            new ButtonCategory("g"     ,true,true),
            new ButtonCategory("h"     ,true,true),
            new ButtonCategory("j"     ,true,true),
            new ButtonCategory("k"     ,true,false),
            new ButtonCategory("l"     ,true,true),
            new ButtonCategory("^"     ,false,true),
            new ButtonCategory("z"     ,true,true),
            new ButtonCategory("x"     ,true,true),
            new ButtonCategory("c"     ,true,true),
            new ButtonCategory("v"     ,true,true),
            new ButtonCategory("b"     ,true,true),
            new ButtonCategory("n"     ,true,true),
            new ButtonCategory("m"     ,true,true),
            new ButtonCategory(","     ,true,true),
            new ButtonCategory("."     ,true,false),

        };
    public static Dictionary<string, string> LPDictionary = new Dictionary<string, string>()
    {
        {"0","9"},{ "p","o"},{ "l","k"},{".",","}
    };

    public static Dictionary<string, string> RPDictionary = new Dictionary<string, string>()
        {
            {"1","2"},{"q","w" },{"a","s"}
        };

     public static Dictionary<string, DuetStr> BPDictionary = new Dictionary<string, DuetStr>()
        {
         {"2",new DuetStr("1","3") },{"3",new DuetStr("2","3") },{"4",new DuetStr("3","5") }, {"5",new DuetStr("4","6") },
         {"w",new DuetStr("q","e") },{"e",new DuetStr("w","r") },{"r",new DuetStr("e","t") }, {"t",new DuetStr("r","y") },
         {"s",new DuetStr("a","d") },{"d",new DuetStr("s","f") },{"f",new DuetStr("d","g") }, {"g",new DuetStr("f","h") },
         {"x",new DuetStr("z","c") },{"c",new DuetStr("x","v") },{"v",new DuetStr("c","b") }, {"b",new DuetStr("v","n") },

         {"6",new DuetStr("5","7") },{"7",new DuetStr("6","8") },{"8",new DuetStr("7","9") },
         {"y",new DuetStr("t","u") },{"u",new DuetStr("y","i") },{"i",new DuetStr("u","o") },
         {"h",new DuetStr("g","j")},{"j",new DuetStr("h","k") },{"k",new DuetStr("j","l") },
         {"n",new DuetStr("b","m") },{"m",new DuetStr("n",",") },{",",new DuetStr("m",".") }
        };
    }
}
