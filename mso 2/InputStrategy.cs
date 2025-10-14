using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mso_2
{
    internal interface IInputStrategy
    {
        string Read();
    }

    public class ConsoleInput : IInputStrategy
    {
        public string Read() => Console.ReadLine();
    }

    public class FileInput : IInputStrategy
    {
        public string Read() => "Bestand gelezen (simulatie)";
    }
}
