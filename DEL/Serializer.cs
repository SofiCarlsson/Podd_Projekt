using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace DEL
{

    public class Serializer<T>
    {
        private string fileName;

        public string FileName
        {
            set { fileName = value; }
        }

        // Konstruktor som sätter filnamnet med .xml som tillägg
        public Serializer(string fName)
        {
            FileName = fName + ".xml";
        }

        // Serialisera (spara) listan till XML
        public void Serialize(List<T> list)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
            using (FileStream xmlOut = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(xmlOut, list);
            }
        }

        // Deserialisera (ladda) listan från XML
        public List<T> Deserialize()
        {
            if (File.Exists(fileName))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
                using (FileStream xmlIn = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    return (List<T>)xmlSerializer.Deserialize(xmlIn);
                }
            }
            return new List<T>(); // Returnerar en tom lista om filen inte finns
        }
    }
}

