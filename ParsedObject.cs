using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbRefactorParser
{
    internal class ParsedObject
    {
        public string RecordName { get; set; }
        public string SetName { get; set; }
        public List<string> FieldsList { get; set; } = new();
        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("{");
            result.Append($"\n\trecord-name: \"{RecordName}\"");
            result.Append($"\n\tset-name: \"{SetName}\"");
            if(FieldsList.Count > 0)
            {
                result.Append($"\n\tfields-list:");
                result.Append($"\n\t[");
                foreach ( var field in FieldsList )
                {
                    result.Append($"\n\t\t\"{field}\"");
                }
                result.Append($"\n\t]");
            }
            result.Append("\n}");
            return result.ToString();   
        }
    }
}
