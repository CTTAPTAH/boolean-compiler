using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto
{
    public class IdentifierInfo
    {
        public string Name { get; set; }
        public bool Value { get; set; }
        public int LineDeclared { get; set; }
        public int LineInitialized { get; set; }
        public bool IsUsed { get; set; } = false;

        public IdentifierInfo(string name, int lineDeclared, int lineInitialized)
        {
            Name = name;
            LineDeclared = lineDeclared;
            LineInitialized = lineInitialized;
            Value = false;
        }
        public IdentifierInfo(string name, int lineDeclared)
        {
            Name = name;
            LineDeclared = lineDeclared;
            LineInitialized = -1;
            Value = false;
        }
    }
}
