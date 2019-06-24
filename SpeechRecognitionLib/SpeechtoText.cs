using System;
using Microsoft.CognitiveServices.Speech;
using System.Threading.Tasks;
using Utility;

namespace SpeechRecognitionLib
{
    public class SpeechToText
    {
        public async Task<string> ConvertSpeechtoTextFromMicrophone()
        {            
            SpeechConfig config = SpeechConfig.FromSubscription(Subscription.key, Subscription.region);
            string result = string.Empty;

            using (var recognizer = new SpeechRecognizer(config))
            {                
                var recognizerAsync = await recognizer.RecognizeOnceAsync().ConfigureAwait(false);

                if (recognizerAsync.Reason == ResultReason.RecognizedSpeech) result += recognizerAsync.Text;
                else if (recognizerAsync.Reason == ResultReason.NoMatch) result += ("Error");
                else if (recognizerAsync.Reason == ResultReason.Canceled)
                {
                    var cancellation = CancellationDetails.FromResult(recognizerAsync);
                    result +=  ($"CANCELED: Reason={cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        result += ($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                        result += ($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                        result += ($"CANCELED: Did you update the subscription info?");
                    }
                }

            }

            return result;
        }
    }
}
