using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Reflection;
using Newtonsoft.Json.Linq;
using NoAvailablePropertiesExceptionCore;
using HumanCore;
using System.Runtime.Serialization.Json;

namespace SerializationCore
{
    public class Serialization 
    {
        public static void Serialize(object obj, string name)
        {
            var ListOfPropertiesForNonSerialize = PrepareProrertyToNoSerialization(obj);

            try
            {
                if (ListOfPropertiesForNonSerialize.Count() == obj.GetType().GetProperties().Count())
                {
                    throw new NoAvailablePropertiesException();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("OOOPS");
                return;
            }

            string serializableObject = JsonSerializer.Serialize<object>(obj);

            JObject jObject = JObject.Parse(serializableObject);

            var temp = new JArray(jObject);

            foreach(var item in ListOfPropertiesForNonSerialize)
            {
                temp.Descendants()
               .OfType<JProperty>()
               .Where(attr => attr.Name == item.Name)
               .ToList()
               .ForEach(attr => attr.Remove());
                
            }

            serializableObject = temp.ToString();

            serializableObject = serializableObject.Replace("\r\n", "");
            serializableObject = serializableObject.Replace("[", "");
            serializableObject = serializableObject.Replace("]", "");

            System.IO.File.WriteAllText(name, serializableObject);
        }

        public static List<PropertyInfo> PrepareProrertyToNoSerialization(object obj)
        {
            var objType = obj.GetType();
            var listOfProperties = objType.GetProperties();
            List<PropertyInfo> PropertiesWithMyIgnoreAttribute = new List<PropertyInfo>();

            foreach (PropertyInfo item in listOfProperties)
            {
                if (item.CustomAttributes.Any(x => x.AttributeType.Name == "MyIgnoreAttribute"))
                {
                    PropertiesWithMyIgnoreAttribute.Add(item);
                }
            }

            return PropertiesWithMyIgnoreAttribute;
        }
    }

}
