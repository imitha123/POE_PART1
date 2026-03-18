using System;
using static System.Console;

namespace POE_PART1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // object instance creations
            greeting_voice system_voice = new greeting_voice();

            ascii_art my_ascii_art = new ascii_art();
            my_ascii_art.dispaly_art();

            user_interaction user_interact = new user_interaction();
            user_interact.prompt();
            user_interact.response_method();

         
        }
    }
}
