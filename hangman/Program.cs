using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using hangman.Classes;

/*
Purpose:        created a Hangman game for the Mini Project - runs out of console
Input:          word, lives, guess, restart
Output:         display of the game space
Written By:     Adam Pumphrey
Last Modified:  Nov. 23, 2020
*/

/* 
Topics from class used include:
 * if/else if/else
 * switch
 * input validation
 * methods
 * classes/objects
 * loops (for, foreach, while, do-while)
 * lists
 * parallel lists
 * Random
*/

/* 
External topics used include:
 * dictionaries
 * recursion
 * regular expressions
 * optional parameters
 * auto implemented property
*/

namespace hangman
{
    class Program
    {
        #region Hangman
        static void Main(string[] args)
        {
            bool result;

            char restart,
                 randomOption;

            string word;

            List<char> wordList = new List<char>();
            List<char> wordMask = new List<char>();

            List<string> randomWordList =  new List<string> { "support", "surface", "affair", "meaning", "deteriorate", "photograph", 
                                                              "squash", "arena", "penalty", "ceiling", "tradition", "bulletin", 
                                                              "feminine", "infrastructure", "chorus", "parachute", "episode",
                                                              "superintendent", "paragraph", "platform", "ground", "protection",
                                                              "copyright", "bread", "complex", "cultivate", "feature", "session", 
                                                              "illustrate", "certain", "lawyer", "network", "narrow", "salad", 
                                                              "proportion", "assertive", "smooth", "arrange", "abuse", "grass",
                                                              "exceed", "joystick", "circle", "panic", "dramatic", "houseplant",
                                                              "river", "television", "athlete", "window" };
            List<string> usedWords = new List<string>();

            Console.Title = "Hangman";

            do
            {
                // game setup
                // choice to use random word
                randomOption = GetSafeChar("Would you like to use a random word? (Y/N): ", true);
                // since the word is removed once it used for a game, need to check to see if randomWordList is empty
                if (randomOption == 'Y' && randomWordList.Count > 0)
                {
                    // randomly choose word from list
                    Random random = new Random();
                    int index = random.Next(randomWordList.Count);
                    word = randomWordList[index].ToUpper();
                    // add word to usedWords list so that you can't replay the word (want the experience to be different every time)
                    usedWords.Add(randomWordList[index]);
                    randomWordList.RemoveAt(index);
                }
                else if (randomWordList.Count == 0)
                {
                    Console.WriteLine("\nThere are no more random words to use. Restart program or enter a word manually.");
                    word = GetSafeString("Enter the mystery word: ").ToUpper();
                }
                else
                {
                    word = GetSafeString("Enter the mystery word: ").ToUpper();
                }
                CreateWordMask(word, wordList, wordMask);
                int lives = GetSafeInt("Enter number of lives (3, 6, or 9): ");
                int livesRemaining = lives;
                Console.Clear();

                // create board
                Board board = new Board(word, lives);

                // run game
                result = Process(board, word, wordList, wordMask, lives, livesRemaining);

                // if the player won the game
                if (result)
                {
                    Console.WriteLine("\nCongratulations!! You win!");
                }
                // if the player lost the game
                else
                {
                    Console.WriteLine("\nGame over. The mystery word was {0}.", word);
                }

                restart = GetSafeChar("\nWould you like to start a new game? (Y/N): ", true);
                if (restart == 'Y')
                {
                    // reset game
                    wordList.Clear();
                    wordMask.Clear();
                    Console.Clear();
                }
            } while (restart != 'N');

            Console.WriteLine("\nProgram ended.");
            Console.ReadLine();
        }

        static void CreateWordMask(string word, List<char> wordList, List<char> wordMask)
        {
            // create blank space for each letter in the word
            for (int i = 0; i < word.Length; i++)
            {
                wordList.Add(word[i]);
                wordMask.Add('_');
            }
        }

        static bool Process(Board board, string word, List<char> wordList, List<char> wordMask, int lives, int livesRemaining)
        {
            char guess;
            bool isValid = false;
            do
            {
                DisplayBoard(wordMask, lives, livesRemaining);
                guess = GetGuess(board);
                // ? char used to denote early exit
                if (guess == '?')
                {
                    Console.WriteLine("\nQuitting...");
                    isValid = true;
                }
                else
                {
                    // change letter to 'guessed' state - can't be guessed again
                    board.Guesses[guess] = 1;
                    // use regex to find all indexes of guess inside mystery word
                    string pattern = "[" + guess + "]";
                    MatchCollection matches = Regex.Matches(word, pattern);
                    // if a correct guess
                    if (matches.Count != 0)
                    {
                        // for each occurrence of the guessed letter
                        foreach (Match match in matches)
                        {
                            // reveal correct letters in mask
                            wordMask[match.Index] = wordList[match.Index];
                        }
                        // if word has been solved
                        if (wordMask.IndexOf('_') == -1)
                        {
                            DisplayBoard(wordMask, lives, livesRemaining);
                            return true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nIncorrect guess.");
                        // remove life for incorrect guess
                        livesRemaining -= 1;
                        // display remaining lives
                        if (livesRemaining > 1)
                        {
                            Console.WriteLine("You now have {0} lives left.", livesRemaining);
                        }
                        else if (livesRemaining == 1)
                        {
                            Console.WriteLine("You now have 1 life left.");
                        }
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        // game over
                        if (livesRemaining == 0)
                        {
                            DisplayBoard(wordMask, lives, livesRemaining);
                            return false;
                        }
                    }
                }
            } while (!isValid);
            return false;
        }

        static void DisplayBoard(List<char> wordMask, int lives, int livesRemaining)
        {
            DrawBoard(wordMask, lives, livesRemaining);
            Console.WriteLine();
        }

        static char GetGuess(Board board)
        {
            char guess;

            bool isValid = false;

            do
            {
                guess = GetSafeChar("\nEnter a letter to guess or enter 'quit' to exit: ");
                // ? is quit char
                if (guess != '?')
                {
                    if (board.Guesses[guess] == 0)
                    {
                        // letter is valid and has not been guessed, just return it
                        return guess;
                    }
                    else
                    {
                        Console.WriteLine("\nLetter has already been guessed. Try Again.");
                    }
                }
                else
                {
                    // return exit char
                    isValid = true;
                }
            } while (!isValid);

            return guess;
        }
#endregion

        #region drawing display
        static void DrawBoard(List<char> wordMask, int lives, int livesRemaining)
        {
            Console.Clear();
            Console.WriteLine();
            // drawing top of display
            Console.WriteLine("       ______");
            Console.WriteLine("      |  ____||");
            Console.WriteLine("      | |    ||");
            Console.WriteLine("      | |    ||");

            DrawStructure(lives, livesRemaining);

            DrawBase(wordMask);
            Console.WriteLine();
        }

        // could maybe be a bit simpler but I think recursion works well here
        static void DrawStructure(int lives, int livesRemaining)
        {
            if (livesRemaining == lives)
            {
                DrawPillar(10);
            }
            else
            {
                switch (lives)
                {
                    case 3:
                        if (livesRemaining == 2)
                        {
                            DrawPillarBody();
                        }
                        // livesRemaining == 1
                        else if (livesRemaining == 1)
                        {
                            DrawPillar(3);
                            DrawMan(true);
                            DrawPillar(1);
                        }
                        // no lives remaining
                        else
                        {
                            DrawMan(false, true, true, true, true);
                        }
                        break;

                    case 6:
                        switch (livesRemaining)
                        {
                            case 5:
                                DrawPillarBody();
                                break;

                            case 4:
                                DrawPillar(3);
                                DrawMan(false, true);
                                DrawPillar(3);
                                break;

                            case 3:
                                DrawPillar(3);
                                DrawMan(false, true, true);
                                DrawPillar(3);
                                break;

                            case 2:
                                DrawPillar(3);
                                DrawMan(false, true, true, true);
                                break;

                            case 1:
                                DrawStructure(3, 1);
                                break;

                            default:
                                DrawStructure(3, 0);
                                break;
                        }
                        break;

                    // lives == 9
                    default:
                        switch (livesRemaining)
                        {
                            case 8:
                                DrawPillarBody(true);
                                break;

                            case 7:
                                DrawStructure(6, 5);
                                break;

                            case 6:
                                DrawStructure(6, 4);
                                break;

                            case 5:
                                DrawStructure(6, 3);
                                break;

                            case 4:
                                DrawStructure(6, 2);
                                break;

                            case 3:
                                DrawStructure(3, 1);
                                break;

                            case 2:
                                DrawPillar(2);
                                DrawMan(false, true, true, true, true, true);
                                break;

                            case 1:
                                DrawPillar(1);
                                DrawMan(false, true, true, true, true, true, true);
                                break;

                            default:
                                DrawStructure(3, 0);
                                break;
                        }
                        break;
                }
            }
        }

        static void DrawPillar(int goal)
        {
            int count = 1;
            while (count <= goal)
            {
                Console.WriteLine("      | |    ");
                count++;
            }
        }

        static void DrawPillarBody(bool half = false)
        {
            if (!half)
            {
                DrawPillar(3);
                DrawMan();
                DrawPillar(3);
            }
            else
            {
                DrawPillar(3);
                DrawBody(true);
                DrawPillar(5);
            }

        }

        static void DrawMan(bool armsLegs = false, bool leftArm = false, bool rightArm = false, bool leftLeg = false, bool rightLeg = false,
            bool bot = false, bool mid = false)
        {
            if (!armsLegs)
            {
                if (!leftArm && !rightArm && !leftLeg && !rightLeg)
                {
                    DrawBody();
                }
                else if (leftArm && rightArm && leftLeg && rightLeg)
                {
                    if (!bot && !mid)
                    {
                        DrawHead();
                    }
                    else if (bot && mid)
                    {
                        DrawHead(false, true, true);
                    }
                    else
                    {
                        DrawHead(false, true);
                    }
                    DrawMan(true);

                }
                else if (leftArm && rightArm && leftLeg)
                {
                    DrawArms(true);
                    DrawBody(true);
                    DrawLegs();
                }
                else if (leftArm && rightArm)
                {
                    DrawArms(true);
                    DrawBody(true);
                }
                else
                {
                    DrawArms();
                    DrawBody(true);
                }
            }
            else
            {
                DrawArms(true);
                DrawBody(true);
                DrawLegs(true);
            }
        }

        static void DrawHead(bool all = true, bool bot = false, bool mid = false)
        {
            if (all)
            {
                Console.WriteLine("      | |    __ ");
                Console.WriteLine("      | |   |  |");
                Console.WriteLine("      | |   |__|");
            }
            else if (bot && mid)
            {
                Console.WriteLine("      | |   |  |");
                Console.WriteLine("      | |   |__|");
            }
            else
            {
                Console.WriteLine("      | |   |__|");
            }

        }

        static void DrawArms(bool rightArm = false)
        {
            if (rightArm)
            {
                Console.WriteLine(@"      | |  \ || /");
                Console.WriteLine(@"      | |   \||/");
            }
            else
            {
                Console.WriteLine(@"      | |  \ ||");
                Console.WriteLine(@"      | |   \||");
            }
        }

        static void DrawBody(bool half = false)
        {
            if (half)
            {
                Console.WriteLine("      | |    ||");
                Console.WriteLine("      | |    ||");
            }
            else
            {
                DrawBody(true);
                DrawBody(true);
            }
        }


        static void DrawLegs(bool rightLeg = false)
        {
            if (rightLeg)
            {
                Console.WriteLine(@"      | |   /  \");
                Console.WriteLine(@"      | |  /    \");
            }
            else
            {
                Console.WriteLine(@"      | |   /  ");
                Console.WriteLine(@"      | |  /   ");
            }
        }

        static void DrawBase(List<char> wordMask)
        {
            Console.WriteLine("  ____| |____");
            Console.Write(" |___________|\t\t");
            foreach (char item in wordMask)
            {
                Console.Write(item + " ");
            }
        }
        #endregion

        #region input validation
        static string GetSafeString(string prompt)
        {
            bool isValid = false;
            string word;
            do
            {
                Console.Write(prompt);
                word = Console.ReadLine();
                // use regex to check if input only contains alphabet chars
                string pattern = "^[a-zA-Z]+$";
                Match result = Regex.Match(word, pattern);
                if (result.Success)
                {
                    // arbitrary choice of length
                    if (word.Length >= 5)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input .. please try again. Mystery word must be at least 5 characters.");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid input .. please try again. Mystery word must only contain letters.");
                }
                
            } while (!isValid);
            return word;
        }

        static int GetSafeInt(string prompt)
        {
            bool isValid = false;
            int number = -99;
            do
            {
                try
                {
                    Console.Write(prompt);
                    number = int.Parse(Console.ReadLine());
                    if (number == 3 || number == 6 || number == 9)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input .. please try again. Lives must be either 3, 6, or 9.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input .. please try again. Lives must be either 3, 6, or 9.");
                }
            } while (!isValid);

            return number;
        }

        static char GetSafeChar(string prompt, bool restart = false)
        {
            bool isValid = false;
            char character = '.';
            do
            {
                try
                {
                    Console.Write(prompt);
                    // option to exit game by entering quit as a guess
                    string temp = Console.ReadLine().ToUpper();
                    if (temp.Equals("QUIT"))
                    {
                        // return quit char
                        return '?';
                    }
                    else
                    {
                        character = char.Parse(temp);
                        // ensure that guess entered is an alphabet char
                        if (Char.IsLetter(character))
                        {
                            if (restart)
                            {
                                if (character == 'Y' || character == 'N')
                                {
                                    isValid = true;
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid input. Enter Y to restart or N to exit.");
                                }
                            }
                            else
                            {
                                isValid = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input. Guess must be a letter.");
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nInvalid input .. please try again.");
                }
            } while (!isValid);

            return character;
        }
        #endregion
    }
}
