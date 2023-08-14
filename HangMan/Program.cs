using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HangMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string randomWord = "word";
            List<char> Cguesses = new List<char>();
            List<char> Iguesses = new List<char>();
            char guess;
            int choice;
            string topic;
            bool playing = true;
            bool choosing = true;
            do
            {
                Console.WriteLine("Select a word theme");
                Console.WriteLine("1: Countries");
                Console.WriteLine("2: Animals");
                Console.WriteLine("3: Food");

                if (int.TryParse(Console.ReadLine(), out choice) && (choice <= 3 && choice >= 1))
                {
                    choice--;
                    randomWord = getWord(choice);
                    choosing = false;
                }
                else
                {
                    Console.WriteLine("Select a valid option");
                }
                Console.Clear();
            } while (choosing);
            int lives = ((randomWord.Length) * 2);

            switch (choice)
            {
                case 0:
                    topic = "countries";
                    break;
                case 1:
                    topic = "animals";
                    break;
                case 2:
                    topic = "food";
                    break;
                
            }
            do
            {
                Console.Clear();

                Console.WriteLine();
                for (int i = 0; i <= randomWord.Length - 1; i++)
                {
                    if (Cguesses.Contains(randomWord[i]))
                    {
                        Console.Write(randomWord[i]);
                    }
                    else
                    {
                        Console.Write("_");
                    }
                }
                Console.WriteLine($"The topic is {topic}");

                Console.WriteLine();
                Console.WriteLine($"You have {lives} lives");
                Console.WriteLine("Guess a letter");
                if (char.TryParse(Console.ReadLine().ToLower(), out guess))
                {
                    if (Cguesses.Contains(guess) || Iguesses.Contains(guess))
                    {
                        Console.WriteLine("You have already guessed this letter");
                    }
                    else
                    {
                        if (randomWord.Contains(guess))
                        {
                            Console.WriteLine("Correct");
                            Cguesses.Add(guess);
                        }
                        else
                        {
                            Console.WriteLine("Incorrect");
                            if (Iguesses.Contains(guess) == false)
                            {
                                Iguesses.Add(guess);
                                lives--;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Enter a valid character");
                }
                if (Cguesses.Distinct().Count() == randomWord.Distinct().Count())
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine(randomWord);
                    Console.WriteLine("You have found the word!");
                    playing = false;
                }
                else
                {
                    if (lives == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("You ran out of lives!");
                        playing = false;
                    }
                    Console.ReadKey();
                }
            } while (playing);
            Console.ReadKey();
        }
        public static string getWord(int choice)
        {
            List<string> countries = new List<string>() { "austria", "bahamas", "croatia", "denmark", "ecuador", "georgia", "germany", "granada", "morocco", "moldova", "migeria" };
            List<string> animals = new List<string>() { "jellyfish", "sunbear", "giraffe", "antelope", "tiger", "anaconda", "greatwhite", "baldeagle", "hammerhead", "cuttlefish", "bullfinch" };
            List<string> food = new List<string>() { "almond", "bamboo", "banana", "noodles", "rocket", "burger", "butter", "nougat", "tomato", "shepardspie", "samosa" };
            var random = new Random();
            int i = random.Next(0, 10);
            string word;
            //string topic;
            if (choice == 0)
            {
                word = countries[i];
                //topic = "countries";
            }
            else if (choice == 1)
            {
                word = animals[i];
                //topic = "animals";
            }
            else
            {
                word = food[i];
                //topic = "food";
            }
            return word;
            //return topic;
        }
    }
}
