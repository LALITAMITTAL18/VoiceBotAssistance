using System;
using System.Xml;

namespace Utility
{
    public static class Subscription
    {
        public static string key;
        public static string region;

        static Subscription()
        {
            string path = @"C:\Users\lalit\source\repos\config.xml";

            using (XmlReader reader = XmlReader.Create(path))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        //return only when you have START tag  
                        switch (reader.Name.ToString())
                        {
                            case "key":
                               key =  reader.ReadString();
                                break;
                            case "region":
                                region = reader.ReadString();
                                break;
                        }
                    }                    
                }
            }
        }
    }

    
}
