using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QNAServiceData
{

    public class QNAResponse
    {
        public Answer[] answers { get; set; }
        public object debugInfo { get; set; }
    }

    public class Answer
    {
        public string[] questions { get; set; }
        public string answer { get; set; }
        public float score { get; set; }
        public int id { get; set; }
        public string source { get; set; }
        public Metadata[] metadata { get; set; }
        public Context context { get; set; }
    }

    public class Context
    {
        public bool isContextOnly { get; set; }
        public object[] prompts { get; set; }
    }

    public class Metadata
    {
        public string name { get; set; }
        public string value { get; set; }
    }
}
