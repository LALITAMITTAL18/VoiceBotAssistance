using System;
using SpeechRecognitionLib;
using System.Threading.Tasks;

namespace VoiceBotAssistance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start saying something...");            
            
            Task<string> response =  StartSpeechToText();
            Console.WriteLine("You said" + response.Result);
            TextToSpeech textToSpeech = new TextToSpeech();

            textToSpeech.CovertTextToSpeechFromMicrophone(response.Result.ToString()).Wait();

            Console.WriteLine("Please press a key to continue.");
            Console.ReadLine();
        }

        private static async Task<string> StartSpeechToText()
        {
            SpeechToText obj = new SpeechToText();
            return await obj.ConvertSpeechtoTextFromMicrophone();
        }
    }
}
