using System;
using SpeechRecognitionLib;

namespace VoiceBotAssistance
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeechToText obj = new SpeechToText();
            obj.GetTextFromMicrophone().Wait();
            Console.WriteLine("Please press a key to continue.");
            Console.ReadLine();
        }
    }
}
