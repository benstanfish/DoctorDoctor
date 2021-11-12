using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DoctorDoctor
{
    public class Wingding
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlElement]
        public string Color { get; set; }
        [XmlElement]
        public int Number { get; set; }

        public Wingding()
        {   
        }

        public Wingding(string name, string color, int number)
        {
            
            Name = name;    
            Color = color;
            Number = number;
        }

        public void Write(string filePath)
        {
            var xml = new XmlSerializer(typeof(Wingding));
            if (File.Exists(filePath))
                File.Delete(filePath);
            var writer = new StreamWriter(filePath);
            xml.Serialize(writer, this);
            writer.Close();
        }

        public static Wingding Read(string filePath)
        {
            var xml = new XmlSerializer(typeof(Wingding));
            using (var reader = new StreamReader(filePath))
            {
                return (Wingding)xml.Deserialize(reader);
            }
        }

        public override string ToString()
        {
            return $"My name is {Name}, my hair color is {Color} and I have {Number} green shirts.";
        }

    }
}
