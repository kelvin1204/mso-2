using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mso_2
{
    internal static class InputFactory
    {
        public static IInputStrategy Create(string type)
        {
            return type switch
            {
                "console" => new ConsoleInput(),
                "file" => new FileInput(),
                _ => throw new ArgumentException("Onbekend inputtype")
            };
        }
    }
}
