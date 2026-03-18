using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace POE_PART1
{
    public class user_interaction
    {
        // global variable
        string name;

        // my contructor
       public void prompt()
        {
            //prompt the user
            Console.Write("Kindly give me your name please >> ");
              name = Console.ReadLine();

            // greet the user
            Console.WriteLine("Hi " + name_validation() + ", Welcome to SuperBot");
            ascii_art my_ascii_art = new ascii_art();
            Console.WriteLine("*************************************");
        }


        // validate method
        public string name_validation()
        {
           
            // conditional statement
            if (String.IsNullOrEmpty(name))
            {
                // loop through if the name is empty
                while (String.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Incorrect, the name can't be empty!");
                    Console.Write("Please try again >> ");
                    name = Console.ReadLine();

                }
            }
            // conditional statement
            if (name.Length <= 2 || !Regex.IsMatch(name, @"^[a - zA - Z]+$"))
            {
                    while (name.Length <= 2 || !Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                    {
                    // loop through if the name is less than 2 characters or contains non-letter characters
                    if (name.Length <= 2)
                    {
                        Console.WriteLine("Incorrect, User name can't be less than 2 characters!");
                        Console.Write("Please try again >> ");
                        name = Console.ReadLine();
                    }
                    // loop through if the name contains non-letter characters
                    if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                    {
                        Console.WriteLine("Incorrect, User name should only contain letters!");
                        Console.Write("Please try again >> ");
                        name = Console.ReadLine();
                    }
                    // loop through if the name is empty
                    if (String.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("Incorrect, User name can't empty!");
                            Console.Write("Please try again >> ");
                            name = Console.ReadLine();
                            Console.WriteLine();
                        }

                    }
  
            }

            return name;
        }
        // method for responses
        public void response_method()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(name_validation() + ": ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                string question = Console.ReadLine().ToLower();

                if (question.Equals("exit"))
                {
                    Console.ResetColor();
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("SuperBot: ");
                expected_keys(question);

                Console.WriteLine();
            }
           

        }
        // method to return the split array
       public string[] split_function(string input)
        {
            string[] split = input.Split(' ', ',','?','.');

            return split;
        }
        // expected keys from the split array
        public void expected_keys(string question)
        {
          Dictionary<string,string> answer = new Dictionary<string,string>();

            answer.Add("hi", "Hello!");
            answer.Add("how", "I am good thanks for asking!");
            answer.Add("purpose", "My purpose is to assist with any CyberSecurity related questions.");
            answer.Add("ask", "You can ask me about Password Safety, Phishing and Safe Browsing.");
            answer.Add("phishing", "Phishing is a type of cyber attack where someone tries to trick you into giving away sensitive information like passwords, bank details, or personal data.");
            answer.Add("password safety", "Password safety is the practice of creating, managing, and protecting your passwords so that unauthorized people (like hackers) can’t access your accounts.");
            answer.Add("safe browsing", "Safe browsing means using the internet in a way that protects you from threats like scams, malware, and data theft.");

            bool found = false;

            foreach (string e in split_function(question))
            {
                if (answer.ContainsKey(e))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(answer[e]);
                    found = true;
                }

            }
            if (found.Equals(false))
            {
                // loop through the split array to check for two-word phrases
                for (int i = 0; i < split_function(question).Length - 1; i++)
                {
                    string phrase = split_function(question)[i] + " " + split_function(question)[i + 1];

                    if (answer.ContainsKey(phrase))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(answer[phrase]);
                        found = true;
                    }
                }

                if (found.Equals(false))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("I didn't quite understand that. Could you rephrase?");
                }
              
            }

            Console.ResetColor();
        }
       
    }
}