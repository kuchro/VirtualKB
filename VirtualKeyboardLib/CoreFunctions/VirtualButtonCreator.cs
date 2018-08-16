using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VStaticData;

namespace VirtualKeyboardLib.CoreFunctions
{
    public static class VirtualButtonCreator
    {
        static List<ButtonCategory> lOnlyRightPairs;
        static List<ButtonCategory> lOnlyLeftPairs;
        static List<ButtonCategory> BothPairs;

        static Dictionary<string, string> LeftPairsDict;
        static Dictionary<string, string> RightPairsDict;
        static Dictionary<string, DuetStr> BothPairsDict;



        public static KeyboardDetails CreateVirtualButton(KeyboardDetails oMissingWords, KeyboardDetails oVKeyboard)
        {
            foreach (var item in oMissingWords)
            {
              oVKeyboard.Add(item.Key,CreateVirtualButton(item.Key, oVKeyboard));
            }
            return oVKeyboard;
        }

        private static ButtonDetails CreateVirtualButton(string MissingButton, KeyboardDetails oData)
        {
            string ButtonCategory = ClassifyButton(MissingButton);

            switch (ButtonCategory)
            {
                case "leftpair":
                    return FindPositionForMissingButtonLP(MissingButton,oData);
                case "rightpair":
                    return FindPositionForMissingButtonRP(MissingButton, oData); 
                case "bothpair":
                    return FindPositionForMissingButtonBP(MissingButton, oData);
                default:
                    return null;
            }
        }

        

        /// <summary>
        /// Classify button to button ranges.
        /// </summary>
        /// <param name="MissingButton"></param>
        /// <returns></returns>
        private static string ClassifyButton(string MissingButton)
        {
            string result = "none";
            var LeftPair = LoadStaticDataLP().Exists(x => x.ButtonCharacter == MissingButton);
            var RightPair = LoadStaticDataRP().Exists(x => x.ButtonCharacter == MissingButton);
            var BothPair = LoadStaticDataBP().Exists(x => x.ButtonCharacter == MissingButton);
            if (LeftPair&&!RightPair&&!BothPair)
            {
                result="leftpair";
            }else if (RightPair&&!LeftPair&!BothPair)
            {
                result = "rightpair";
            }else if (BothPair&&!RightPair&&!LeftPair)
            {
                result = "bothpair";
            }
            return result;
        }

        private static ButtonDetails FindPositionForMissingButtonLP(string MissingButton, 
            KeyboardDetails ListOfAvailableButtons)
        {
           var SideButton = LoadLeftPairsStaticData().Where(x => x.Key == MissingButton).Select(x => x.Value).FirstOrDefault();
           var LeftButton = ListOfAvailableButtons.Where(x => x.Key == SideButton).Select(o => o.Value).FirstOrDefault();
           int oWidth = GetWidthBetweenButtons(LeftButton.Y, ListOfAvailableButtons);
            return new ButtonDetails(LeftButton.X + oWidth,LeftButton.Y);
        }

       

        private static ButtonDetails FindPositionForMissingButtonRP(string MissingButton,
            KeyboardDetails ListOfAvailableButtons)
        {
            var SideButton = LoadRightPairsStaticData().Where(x => x.Key== MissingButton).Select(x => x.Value).FirstOrDefault();
            var RightButton = ListOfAvailableButtons.Where(x => x.Key == SideButton).Select(o => o.Value).FirstOrDefault();
            int oWidth = GetWidthBetweenButtons(RightButton.Y, ListOfAvailableButtons);
            return new ButtonDetails(RightButton.X + oWidth, RightButton.Y);
        }
        private static ButtonDetails FindPositionForMissingButtonBP(string MissingButton, KeyboardDetails oData)
        {
            var SideButton = LoadBothPairsStaticData().Where(x => x.Key == MissingButton).Select(x => x.Value).FirstOrDefault();
            var LeftButton = oData.Where(x => x.Key == SideButton.Item1).Select(o=>o.Value).FirstOrDefault();
            var RightButton = oData.Where(x => x.Key == SideButton.Item2).Select(o => o.Value).FirstOrDefault();
            var MidPos = ((RightButton.X - LeftButton.X))+LeftButton.X;
            return new ButtonDetails(MidPos,LeftButton.Y);
        }



        #region GetAnotherButton
        private static int GetWidthBetweenButtons(int Y, KeyboardDetails ListOfAvailableButtons)
        {
            var BothPair = false;
            var CheckIfExist = false;
            KeyValuePair<string, ButtonDetails> RandomButton = ListOfAvailableButtons.OrderBy(x => Math.Abs(Y - x.Value.Y)).FirstOrDefault();
            var SideButton = LoadBothPairsStaticData().Where(x => x.Key == RandomButton.Key).Select(x => x.Value).FirstOrDefault();
            CheckIfExist = ListOfAvailableButtons.Keys.ToList().Exists(x=>x==SideButton.Item1&& x== SideButton.Item2);
            BothPair = LoadStaticDataBP().Exists(x => x.ButtonCharacter == RandomButton.Key);
            while (!(BothPair && CheckIfExist))
            {
                RandomButton = GetAnotherButton(ClassifyButton(RandomButton.Key), RandomButton.Key, ListOfAvailableButtons);
                BothPair = LoadStaticDataBP().Exists(x => x.ButtonCharacter == RandomButton.Key);
                CheckIfExist = ListOfAvailableButtons.Keys.ToList().Exists(x => x != SideButton.Item1 && x != SideButton.Item2);
                SideButton = LoadBothPairsStaticData().Where(x => x.Key == RandomButton.Key).Select(x => x.Value).FirstOrDefault();
            }
            var LeftButton = ListOfAvailableButtons.Where(x => x.Key == SideButton.Item1).Select(o => o.Value).FirstOrDefault();
            var RightButton = ListOfAvailableButtons.Where(x => x.Key == SideButton.Item2).Select(o => o.Value).FirstOrDefault();
            var MidPos = ((RightButton.X - LeftButton.X));
            return MidPos;

        }

        private static dynamic GetAnotherButton(string Path, string Key, KeyboardDetails ListOfAvailableButtons)
        {
            switch (Path)
            {
                case "leftpair":
                    var SideButton1 = LoadLeftPairsStaticData().Where(x => x.Key == Key).FirstOrDefault();
                    return ListOfAvailableButtons.Where(x => x.Key == SideButton1.Value).Select(o => o.Value).FirstOrDefault();
                case "rightpair":
                    var SideButton2 = LoadRightPairsStaticData().Where(x => x.Key == Key).FirstOrDefault();
                    return ListOfAvailableButtons.Where(x => x.Key == SideButton2.Value).FirstOrDefault();
                case "bothpair":
                    var SideButton3 = LoadBothPairsStaticData().Where(x => x.Key == Key).FirstOrDefault();
                    return ListOfAvailableButtons.Where(x => x.Key == SideButton3.Value.Item2).FirstOrDefault();
                default:
                    return null;
            }
        }

        #endregion

        #region Loaders
        private static List<ButtonCategory> LoadStaticDataLP()
        {
            if (lOnlyLeftPairs == null)
            {
               return lOnlyLeftPairs = StaticDataClass.ButtonCategories.
                    Where(x => x.RPair == false && x.LPair == true).ToList();
            }
            else
            {
                return lOnlyLeftPairs;
            }
                
        }

        private static List<ButtonCategory> LoadStaticDataRP()
        {
            if (lOnlyRightPairs == null)
            {
                return lOnlyRightPairs = StaticDataClass.ButtonCategories.
                    Where(x => x.RPair == true && x.LPair == false).ToList();
            }
            else
            {
                return lOnlyRightPairs;
            }
        }

        private static List<ButtonCategory> LoadStaticDataBP()
        {
            if (BothPairs == null)
            {
                return BothPairs = StaticDataClass.ButtonCategories.
                    Where(x => x.LPair == true && x.RPair == true).ToList();
            }
            else
            {
                return BothPairs;
            }
        }

        #endregion Loaders

        #region ButtonPairsStaticLoaders

        private static Dictionary<string, string> LoadLeftPairsStaticData()
        {
            if (LeftPairsDict == null)
            {
                return LeftPairsDict = StaticDataClass.LPDictionary;
            }
            else
            {
                return LeftPairsDict;
            }
        }

        private static Dictionary<string, string> LoadRightPairsStaticData()
        {
            if (RightPairsDict == null)
            {
                return RightPairsDict = StaticDataClass.RPDictionary;
            }
            else
            {
                return RightPairsDict;
            }
        }

        private static Dictionary<string, DuetStr> LoadBothPairsStaticData()
        {
            if (BothPairsDict == null)
            {
                return BothPairsDict = StaticDataClass.BPDictionary;
            }
            else
            {
                return BothPairsDict;
            }
        }


        #endregion


    }
}
