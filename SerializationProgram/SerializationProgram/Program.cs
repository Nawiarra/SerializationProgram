using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerializationCore;
using HumanCore;


namespace SerializationProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Gamer gamer = new Gamer("aaaa", "bbbb", 12, true);
            Suicidal suicidal = new Suicidal("cccc", "dddd", 11, 50);
            Serialization.Serialize(gamer, "gamer.json");
            Serialization.Serialize(suicidal, "suicidal.json");
        }
    }
}
