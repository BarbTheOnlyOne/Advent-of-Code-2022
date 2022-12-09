using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode.Day2
{
    internal class RockPaperScissorsComparer
    {
        public int RockValue { get; }
        public int PaperValue { get; }
        public int ScissorsValue { get; }
        public int WinValue { get; }
        public int DrawValue { get; }
        public int LossValue { get; }

        public RockPaperScissorsComparer(int rockValue, int paperValue, int scissorsValue,
            int winValue, int drawValue, int lossValue)
        {
            RockValue = rockValue;
            PaperValue = paperValue;
            ScissorsValue = scissorsValue;
            WinValue = winValue;
            DrawValue = drawValue;
            LossValue = lossValue;
        }

        public int CompareFightPartOne(string elfChoice, string myChoice)
        {
            switch (elfChoice)
            {
                case "A":
                    if (myChoice == "X")
                    {
                        return RockValue + DrawValue;
                    }
                    if (myChoice == "Y")
                    {
                        return PaperValue + WinValue;
                    }

                    return ScissorsValue + LossValue;

                case "B":
                    if (myChoice == "X")
                    {
                        return RockValue + LossValue;
                    }
                    if (myChoice == "Y")
                    {
                        return PaperValue + DrawValue;
                    }

                    return ScissorsValue + WinValue;

                case "C":
                    if (myChoice == "X")
                    {
                        return RockValue + WinValue;
                    }
                    if (myChoice == "Y")
                    {
                        return PaperValue + LossValue;
                    }

                    return ScissorsValue + DrawValue;
            }

            return 0;
        }

        public int CompareFightPartTwo(string elfChoice, string resultOfFight)
        {
            switch (resultOfFight)
            {
                case "Z":
                    if (elfChoice == "A")
                    {
                        return WinValue + PaperValue;
                    }
                    if (elfChoice == "B")
                    {
                        return WinValue + ScissorsValue;
                    }

                    return WinValue + RockValue;

                case "Y":
                    if (elfChoice == "A")
                    {
                        return DrawValue + RockValue;
                    }
                    if (elfChoice == "B")
                    {
                        return DrawValue + PaperValue;
                    }

                    return DrawValue + ScissorsValue;

                case "X":
                    if (elfChoice == "A")
                    {
                        return LossValue + ScissorsValue;
                    }
                    if (elfChoice == "B")
                    {
                        return LossValue + RockValue;
                    }

                    return LossValue + PaperValue;
            }

            return 0;
        }
    }
}
