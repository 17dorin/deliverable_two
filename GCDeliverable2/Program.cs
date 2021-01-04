using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCDeliverable2
{
    class Program
    {
        static void Main(string[] args)
        {
            String headsOrTailsGuess;
            String inputValidation;
            int numberOfFlips;
            int correctCount = 0;
            bool goodInput = false;

            do
            {
                //Get user input
                Console.WriteLine("Enter your guess (either heads or tails)\n");
                inputValidation = Console.ReadLine();

                //Validate heads or tails, store answer
                if(inputValidation.ToLower() == "heads" || inputValidation.ToLower() == "tails")
                {
                    headsOrTailsGuess = inputValidation;
                    Console.WriteLine("Enter how many flips you want to simulate\n");
                    inputValidation = Console.ReadLine();

                    //Validate number of flips, store answer, update control variable
                    if(Int32.TryParse(inputValidation, out numberOfFlips))
                    {
                        goodInput = true;

                        //Simulate Flips, treating a 0 as heads and a 1 as tails
                        Random rand = new Random();
                        for (int i = 0; i < numberOfFlips; i++)
                        {
                            int flip = rand.Next(0, 2);

                            //Check for correct guesses, print flips to console
                            if (flip == 0 && headsOrTailsGuess == "heads")
                            {
                                correctCount++;
                                Console.WriteLine("heads");
                            }
                            else if (flip == 1 && headsOrTailsGuess == "tails")
                            {
                                correctCount++;
                                Console.WriteLine("tails");
                            }
                            else
                            {
                                if (flip == 0)
                                    Console.WriteLine("heads");
                                else
                                    Console.WriteLine("tails");
                            }
                        }
                        //Display Score
                        double score = (((double) correctCount  / (double) numberOfFlips) * 100.0);
                        Console.WriteLine("\n{0} was flipped {1} time(s), for an accuracy of {2}%.\nPress enter to close program", headsOrTailsGuess, correctCount, score);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input\n");
                    }

                }
                else
                {
                    Console.WriteLine("Please enter heads or tails\n");
                }
            } while (goodInput == false);
        }
    }
}
