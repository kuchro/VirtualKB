using CoreFunctions;
using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualKeyboardLib.CoreFunctions;
using VStaticData;

namespace VirtualKeyboardLib.Tests
{
    [TestFixture]
    public class BaseTest
    {
        [Test]
        public void Test()
        {
            var list = new KeyboardDetails();
            string Seq = "2 3 4 5 6 7 8 9 0 q w e r t u i o p a s d f g h j k l ^ z x c v b n m , .";
            var chArr = Seq.Split(' ');
            int X = 54;
            int Y = 1032;

                for (int y = 0; y < 10; y++)
                {
                    list.Add(chArr[y].ToString(), new ButtonDetails(X, Y));
                    X += 100;
                }
                X = 54;
                Y += 100;
                for (int z = 0; z < 10; z++)
                {
                    list.Add(chArr[z+10].ToString(), new ButtonDetails(X, Y));
                    X += 100;
                }
                X = 54;
                Y += 100;
                for (int y = 0; y < 9; y++)
                {
                    list.Add(chArr[y+20].ToString(), new ButtonDetails(X, Y));
                    X += 100;
                }
                X = 54;
                Y += 100;
                for (int y = 0; y < 8; y++)
                {
                    list.Add(chArr[y + 29].ToString(), new ButtonDetails(X, Y));
                    X += 100;
                }

        

            List<ButtonCategory> xx = StaticDataClass.ButtonCategories;

           var oo =  KeyboardChecker.VerifyIfTheresMissingChar(list);

            var onlyright = xx.Where(x => x.RPair == true&& x.LPair==false);

            VirtualButtonCreator.CreateVirtualButton(oo,list);
            Console.WriteLine("sdasdas");
        }
    }
}
