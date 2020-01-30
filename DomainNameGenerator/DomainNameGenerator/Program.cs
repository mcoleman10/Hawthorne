using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainNameGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int j = 0; j <10; j++)
            {
                List<String> dicty = new List<String> { "hawthorne", "developer", "sleeping", "ninja", "mind", "brain", "lead", "follow", "carry", "place", "apple", "pineapple"
                , "guava", "fruit", "lemon", "lime", "you", "real", "sound", "keyboard", "silence", "patience", "end" };
                // Generate random 2+ random words
                Random r = new Random();
                int numWords = r.Next(2, 5);
                String[] words = new string[numWords];
                for (int i = 0; i < numWords; i++)
                {
                    words[i] = GenerateWord(ref dicty);
                    //Console.WriteLine(words[i]);
                    Thread.Sleep(50);
                }
                // Concact generated words together separated by hyphens
                URL link = new URL();
                foreach (String s in words)
                {
                    if (link.url == "")
                        link.url = s;
                    else
                        link.url = link.url + "-" + s;
                }
                // Add TLD to end of string
                String[] tlds = new String[] { ".com", ".net", ".edu", ".gov", ".org" };
                Random r1 = new Random();
                link.tld = tlds[r1.Next(0, tlds.Length)];
                // Output string
                Console.WriteLine(link.url + link.tld);
            }
        }

        static String GenerateWord(ref List<String> words)
        {
            
            Random rnd = new Random();
            int index = rnd.Next(0, words.Count());
            string word = words[index];
            words.RemoveAt(index);
            return word;
        }

        public class URL
        {
            private String _url = "";
            private String _tld = "";

            public string url
            {
                get
                {
                    return this._url;
                }
                set
                {
                    this._url = value;
                }
            }

            public string tld
            {
                get
                {
                    return this._tld;
                }
                set
                {
                    this._tld = value;
                }
            }
        }
    }
}
