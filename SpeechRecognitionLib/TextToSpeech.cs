using System;
using System.Collections.Generic;
using System.Text;
using Utility;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;

namespace SpeechRecognitionLib
{
    public class TextToSpeech
    {
        public async Task CovertTextToSpeechFromMicrophone(string TextToSpeek)
        {

            SpeechConfig config = SpeechConfig.FromSubscription(Subscription.key, Subscription.region);

            // Creates a speech synthesizer using the default speaker as audio output.
            using (var synthesizer = new SpeechSynthesizer(config))
            {
                // Receive a text from console input and synthesize it to speaker.               

                using (var result = await synthesizer.SpeakTextAsync(TextToSpeek))
                {
                    if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                    {
                        Console.WriteLine($"Voice Bot Assistance said :  [{TextToSpeek}]");
                    }
                    else if (result.Reason == ResultReason.Canceled)
                    {
                        var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                        Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                        if (cancellation.Reason == CancellationReason.Error)
                        {
                            Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                            Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                            Console.WriteLine($"CANCELED: Did you update the subscription info?");
                        }
                    }
                }

                // This is to give some time for the speaker to finish playing back the audio
                //Console.WriteLine("Press any key to exit...");
                //Console.ReadKey();
            }
        }
    }
}
