using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace SerializationCore
{
    public class MyIgnoreAttribute : System.Attribute
    {
        public MyIgnoreAttribute()
        { 
        }
    }
    public class Serialization <T>
    {
        public static void Serialize(T obj, string name)
        {
            using (FileStream fs = new FileStream(name, FileMode.OpenOrCreate))
            {
                JsonSerializer.SerializeAsync<T>(fs, obj);
            }
        }

        public static T Deserialize(string name)
        {
            using (FileStream fs = new FileStream(name, FileMode.OpenOrCreate))
            {
                T result = JsonSerializer.Deserialize<T>(name);
                return result;
            }
        }
    }

}
