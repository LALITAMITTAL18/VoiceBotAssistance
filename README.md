# VoiceBotAssistance this is an app to build voice assistance 

I have used Microsoft Cognitive Services to bulid this app. When user speaks it converts it to Text using Microsoft.Speech Azure Service and send the Text to QNA maker service. This Azure Service searches for answer for the question asked via a POST method and sends back to the Calling program i.e. VoiceBotAssitance. Then this Answer sent back to Microsoft.Speech service to play it on our speaker.

To start using this service , update values in configuration file which is present in Utility/Resource folder for below values :
"<?xml version="1.0" encoding="utf-8" standalone="yes"?>
<root>
 <config>
  <key>--Your Microsoft.Speech Key--</key>
  <region>--region what you have selected in Microsoft.Speech--</region>
   <QandAKey>--Your QNA maker Key--</QandAKey>
   <EndPointKey>--Your QNA maker End point--</EndPointKey>
   <kbID>--Your QNA maker KB ID--</kbID>
 </config>
</root> "

for more information you can follow my blog here :

https://lmittal.blogspot.com/2019/06/microsoftcognitiveservicesspeech.html

https://lmittal.blogspot.com/2019/06/voice-bot-assistance-part-2-microsoft.html

Happy chit chatting!!
