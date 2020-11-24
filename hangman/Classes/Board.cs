using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman.Classes
{
    class Board
    {
        private string _word;

        private int _lives;

        public string Word
        {
            get { return _word; }
            set
            {
                // completely arbitrary choice of word length
                if (value.Length >= 5)
                {
                    _word = value;
                }
                else
                {
                    throw new Exception("Mystery word must be at least 5 characters");
                }
            }
        }

        public int Lives
        {
            get { return _lives; }
            set
            {
                if (value == 3 || value == 6 || value == 9)
                {
                    _lives = value;
                }
                else
                {
                    throw new Exception("Number of lives must be either 3, 6, or 9");
                }
            }
        }

        /* 
           auto implemented property
           https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
           https://stackoverflow.com/a/40754
           no set since this is a default value of the Board - there will never be a reason to set another Dictionary
        */
        public Dictionary<char, int> Guesses
        {
            get;
        } = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['B'] = 0,
            ['C'] = 0,
            ['D'] = 0,
            ['E'] = 0,
            ['F'] = 0,
            ['G'] = 0,
            ['H'] = 0,
            ['I'] = 0,
            ['J'] = 0,
            ['K'] = 0,
            ['L'] = 0,
            ['M'] = 0,
            ['N'] = 0,
            ['O'] = 0,
            ['P'] = 0,
            ['Q'] = 0,
            ['R'] = 0,
            ['S'] = 0,
            ['T'] = 0,
            ['U'] = 0,
            ['V'] = 0,
            ['W'] = 0,
            ['X'] = 0,
            ['Y'] = 0,
            ['Z'] = 0,
        };

        // no need to include Guesses since it has a default value already assigned
        public Board(string word, int lives)
        {
            Word = word;
            Lives = lives;
        }
    }
}
