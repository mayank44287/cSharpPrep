using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;

namespace Carnival.DBL
{
    [Serializable]
    public class ReadWriteFile
    { 
        public static List<T> Read<T>()
        {
            List<T> list = new List<T>();
            var type = list.GetType().GetTypeInfo().GenericTypeArguments[0];
            string[] str = type.ToString().Split('.');
            FileStream fs = new FileStream(@"C:\Users\Anshul\Downloads\Compressed\CarnivalCinemas\files\" + str[2] + ".txt", FileMode.Open);
            XmlSerializer xmlserializerobj1 = new XmlSerializer(typeof(List<T>));
            if (fs.Length > 1)
            {
                list = (List<T>)xmlserializerobj1.Deserialize(fs);
 
            }
            fs.Close();
            return list;
        }



        public static void Write<T>(List<T> list)
        {
            var type = list.GetType().GetTypeInfo().GenericTypeArguments[0];
            string[] str = type.ToString().Split('.');
            FileStream fs1 = new FileStream(@"C:\Users\Anshul\Downloads\Compressed\CarnivalCinemas\files\" + str[2] + ".txt", FileMode.Create);
            XmlSerializer xmlserializerobj = new XmlSerializer(typeof(List<T>));
            xmlserializerobj.Serialize(fs1, list);
            fs1.Close();
        }
    }
}
