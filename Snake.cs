using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PA_Test
{
    [XmlType]
    public class Snake
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Type { get; set; } // water, sand, mountain

        public Snake(string name, string type)
        {
            Name = name;
            Type = type;
        }
        public Snake()
        {

        }

        public override string ToString()
        {
            return $"Type: {Type}";
        }
    }
}
