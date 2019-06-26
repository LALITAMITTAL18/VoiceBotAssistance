using System;
using SpeechRecognitionLib;
using System.Threading.Tasks;
using QandAService;

namespace VoiceBotAssistance
{
    class Program
    {
        static void Main(string[] args)
        {
            // Invoke the CreateKB() method to create a knowledge base, periodically 
            // checking the status of the QnA Maker operation until the 
            // knowledge base is created.
            //QandAService.QandAService.CreateKB().Wait();

            // Publish KB. This doesn't return a polling location so there is no
            // need to check status. 
            //QandAService.QandAService.PublishKB().Wait();

            // Get endpoint host name
            //QandAService.QandAService.GetKnowledgeBaseHostNameDetails().Wait();

            //QandAService.QandAService.GetEndpointKeys().Wait();
            //flag to keep continue the conversation
            bool _quitFlag = false;
            Console.CancelKeyPress += delegate
            {
                _quitFlag = true;
            };
            Console.WriteLine("Start saying something...");
            while (!_quitFlag)
            {
                //starting bot
                StartVoiceBot();
            }          

            //Console.WriteLine("Please press a key to continue.");
            //Console.ReadLine();
        }

        /// <summary>
        /// function for invoking bot
        /// </summary>
        private static void StartVoiceBot()
        {           
            //get speech converted to text
            Task<string> response = StartSpeechToText();
            Console.WriteLine("You said : " + response.Result);

            //pass the question to QNA service and retrive response
            Task<string> answer = GetAnswerFromQnAService(response.Result);

            //pass back the answer to speeker
            TextToSpeech textToSpeech = new TextToSpeech();
            textToSpeech.CovertTextToSpeechFromMicrophone(answer.Result.ToString()).Wait();
        }

        /// <summary>
        /// function for converting microphone speech to Text
        /// </summary>
        /// <returns>Task<string></string></returns>
        private static async Task<string> StartSpeechToText()
        {
            SpeechToText obj = new SpeechToText();
            return await obj.ConvertSpeechtoTextFromMicrophone();
        }

        /// <summary>
        /// Send question to QNA service and fetch response
        /// </summary>
        /// <param name="question"></param>
        /// <returns>Task<string></returns>
        private static async Task<string> GetAnswerFromQnAService(string question)
        {
            SpeechToText obj = new SpeechToText();
            return await // Get the top answer to a question
            QandAService.QandAService.GetAnswer(question);
        }
    }
}
