using System;
using Microsoft.CognitiveServices.Speech;
using System.Threading.Tasks;

namespace SpeechRecognitionLib
{
    public class SpeechToText
    {
        public async Task GetTextFromMicrophone()
        {
            SpeechConfig config = SpeechConfig.FromSubscription("", "westus");
            string result = string.Empty;

            using (var recognizer = new SpeechRecognizer(config))
            {
                Console.WriteLine("Start saying something...");
                var recognizerAsync = await recognizer.RecognizeOnceAsync().ConfigureAwait(false);

                if (recognizerAsync.Reason == ResultReason.RecognizedSpeech) Console.WriteLine(recognizerAsync.Text);
                else if (recognizerAsync.Reason == ResultReason.NoMatch) Console.WriteLine("Error");
                else if (recognizerAsync.Reason == ResultReason.Canceled)
                {
                    var cancellation = CancellationDetails.FromResult(recognizerAsync);
                    Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                        Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                        Console.WriteLine($"CANCELED: Did you update the subscription info?");
                    }
                }

            }
        }
    }
}
