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
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SerializationCore
{
    public class Serialization
    {
        object SerializableObject = new object();
        public static void Serialize(object obj, string name) 
        {
            var ListOfPropertiesForNonSerialize = PrepareProrertyToNoSerialization(obj);

            if (ListOfPropertiesForNonSerialize.Count() == obj.GetType().GetProperties().Count())
            {
                 throw new NoAvailablePropertiesException();
            }

            string serializableObject = System.Text.Json.JsonSerializer.Serialize<object>(obj);

            var temp = new JArray(serializableObject);

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
