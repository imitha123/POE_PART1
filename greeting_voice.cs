using System;
using System.IO;
using System.Media;
using static System.Console;

namespace POE_PART1
{
    internal class greeting_voice
    {
        //my constructor
        public greeting_voice()
        {
            // full path of the recording
            string path_directory = AppDomain.CurrentDomain.BaseDirectory;
            //back track to get the exact location of the record
            string recordPath = path_directory.Replace("\\bin\\Debug", "");
            // combine the location and the recording it's to play it
            string record = Path.Combine(recordPath, "Recording.wav");
            play_voice(record);
        }
        // method to play the voice recording
        public void play_voice(string voice)
        {
            // error handling
            try
            {
                using (SoundPlayer speechObj = new SoundPlayer(voice))
                {
                    speechObj.PlaySync();
                }

            }
            // if the file is not found or any other error occurs, it will be caught here
            catch (Exception e)
            {
                WriteLine($"{e.Message}");

            }
        }
    }
}