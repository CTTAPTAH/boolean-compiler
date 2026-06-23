using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto
{
    // Структура лексемы
    public class Token
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Line { get; set; }

        public Token(string name, string type, int line)
        {
            Name = name;
            Type = type;
            Line = line;
        }
    }
}
