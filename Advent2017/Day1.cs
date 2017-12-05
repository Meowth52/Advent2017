using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    internal class Day1
    {
        private string Input;
        private readonly MainView _mainView;
        public Day1(string input, MainView mainView)
        {
            Input = input.Replace("\r\n", "");
            _mainView = mainView;
        }
        
        public string Result()
        {
            _mainView.OutText = "blärp";
            string st = "" + Input.Last();
            int LastNumber = 0;
            Int32.TryParse(st, out LastNumber);
            int CurrentNumber = 0;
            int Sum = 0;
            int Sum2 = 0;
            foreach (char c in Input)
            {
                string s = "" + c;
                Int32.TryParse(s, out CurrentNumber);
                if (LastNumber == CurrentNumber)
                {
                    Sum = Sum + CurrentNumber;
                }
                    LastNumber = CurrentNumber;
            }
            for (int i = 0; i < Input.Length; i++)
            {
                string s = "" + Input[i];
                int Number = 0;
                int offset = Input.Length/2 + i + 1;
                if (offset > Input.Length)
                    offset -= Input.Length;
                if (Input[i] == Input[offset-1])
                {
                    Int32.TryParse(s, out Number);
                    Sum2 += Number;
                }
            }
            return Sum.ToString() + " och del 2 " + Sum2.ToString();
        }
    }
}
