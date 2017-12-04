using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class Day4
    {
        private string Input;
        private string[] Instructions;
        public Day4(string input)
        {
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
        }

        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            List<string> Passphrase = new List<string>();
            bool PassphraseOK;
            foreach (string s in Instructions)
            {
                if (s != "")
                {
                    PassphraseOK = true;
                    Passphrase.Clear();
                    string[] Words;
                    Words = s.Split(' ');
                    foreach (string w in Words)
                    {
                        if (Passphrase.Contains(w))
                            PassphraseOK = false;
                        Passphrase.Add(w);
                    }
                    if (PassphraseOK)
                        Sum++;
                }
            }
            foreach (string s in Instructions)
            {
                if (s != "")
                {
                    PassphraseOK = true;
                    Passphrase.Clear();
                    string[] Words;
                    Words = s.Split(' ');
                    foreach (string w in Words)
                    {
                        foreach(string p in Passphrase)
                        {
                            List<char> CharacterList1 = new List<char>();
                            List<char> CharacterList2 = new List<char>();
                            foreach (char c in p)
                                CharacterList1.Add(c);
                            foreach (char c in w)
                                CharacterList2.Add(c);
                            CharacterList1.Sort();
                            CharacterList2.Sort();                            
                            if (Enumerable.SequenceEqual(CharacterList1, CharacterList2))
                                PassphraseOK = false;
                        }
                        Passphrase.Add(w);
                    }
                    if (PassphraseOK)
                        Sum2++;
                }
            }
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString();
        }
        
    }
}
