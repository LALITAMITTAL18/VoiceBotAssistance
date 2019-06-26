using System;
using System.Xml;

namespace Utility
{
    public static class Subscription
    {
        public static string key;
        public static string region;
        public static string QandAKey;
        public static string kbID;
        public static string EndPointKey;

        /// <summary>
        /// get all configuration value map to field from Azure services
        /// </summary>
        static Subscription()
        {            
            string path = System.IO.Path.GetFullPath(".\\Resources\\config.xml");

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
                            case "QandAKey":
                                QandAKey = reader.ReadString();
                                break;
                            case "kbID":
                                kbID = reader.ReadString();
                                break;
                            case "EndPointKey":
                                EndPointKey = reader.ReadString();
                                break;

                        }
                    }                    
                }
            }
        }
    }

    
}
