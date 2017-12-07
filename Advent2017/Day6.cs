using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class Day6
    {
        private string Input;
        private string[] Instructions;
        public Day6(string input)
        {
            Input = input.Replace("\r\n", "");
            Instructions = Input.Split(' ');
        }

        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            int TryParseInt = 0;
            int Iterator = 0;
            int MovingBank;
            int[] BankBank = new int[16];
            List<string> StateBank= new List<string>();
            string CurrentState="";
            foreach (string s in Instructions)
            {
                Int32.TryParse(s, out TryParseInt);
                BankBank[Iterator] = TryParseInt;
                CurrentState += TryParseInt.ToString() + "_";
                Iterator++;
            }
            StateBank.Add(CurrentState);
            CurrentState = "";
            while (!StateBank.Contains(CurrentState))
            {
                StateBank.Add(CurrentState);
                CurrentState = "";
                Sum++;
                int Comparer = 0;
                int IndexOfHighestBank=0;
                for (int i = 0; i <= 15; i++)
                {
                    if (BankBank[i] > Comparer)
                    {
                        IndexOfHighestBank = i;
                        Comparer = BankBank[i];
                    }
                }
                MovingBank = BankBank[IndexOfHighestBank];
                BankBank[IndexOfHighestBank] = 0;
                for (; MovingBank > 0; MovingBank--)
                {
                    IndexOfHighestBank++;
                    if (IndexOfHighestBank > 15)
                        IndexOfHighestBank = 0;
                    BankBank[IndexOfHighestBank]++;
                }
                foreach(int i in BankBank)
                    CurrentState += i.ToString() + "_";
            }
            Sum2 = StateBank.Count - StateBank.IndexOf(CurrentState);
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString();
        }
    }
}
