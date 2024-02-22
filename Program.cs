using System.IO;
using System.Text.RegularExpressions;

namespace DbRefactorParser
{
//find-st3 ::= “Find “ [“Next ” |”First “ |”Prior “ |”Last “] rec-name => ident 
//“Record “ “In “ set-name =>ident “Set “ 
//[“Using ” field-list => list-ident]! “;” ;

//list-ident ::= [item-name => ident]+ “;” ;
    internal class Program
    {
        static void Main()
        {
            var sr = new StreamReader("D:\\Prog\\C#\\DbRefactorParser\\input2.txt");
            var line = sr.ReadToEnd();
            var regex = new Regex(@"Find\s+(?:Next|First|Prior|Last)\s+(\w+)\s+Record\s+In\s+(\w+)\s+Set\s*(?:\sUsing\s+(.+)){0,1}\s*;");
            var matches = regex.Matches(line);
            var obj = new ParsedObject();
            if (matches == null || matches.Count == 0) throw new Exception("No match found");
            var groups = matches.First().Groups;
            if (matches != null && matches.First().Groups.Count>2) 
            {
                obj.RecordName = groups[1].Value;
                obj.SetName = groups[2].Value;
                if(groups.Count > 3)
                {
                    var regex1 = new Regex(@"(\w+)");
                    var matches1 = regex1.Matches(groups[3].Value);
                    for (int i = 0; i < matches1.Count; i++)
                    {
                        obj.FieldsList.Add(matches1[i].Value);
                    }
                }
            }
            var objStr = obj.ToString();
            using (StreamWriter writer = new StreamWriter("D:\\Prog\\C#\\DbRefactorParser\\output.txt", false))
            {
                writer.Write(objStr);
            }
        }
    }
}