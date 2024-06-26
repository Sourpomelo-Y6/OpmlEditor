﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;

namespace OpmlEditor
{

    [XmlRoot("opml")]
    public class Opml
    {
        [XmlAttribute("version")]
        public string version = "2.0";
        public Head head { get; set; }
        public Body body { get; set; }
    }

    public class Head
    {
        public string title { get; set; }
    }

    public class Body
    {
        [XmlElement("outline")]
        public List<Outline> outlines { get; set; }
    }

    public class Outline
    {
        [XmlAttribute("text")]
        public string text { get; set; }

        [XmlAttribute("description")]
        public string desctiption { get; set; }

        [XmlAttribute("title")]
        public string title { get; set; }

        [XmlElement("outline")]
        public List<Outline> SubOutlines { get; set; }

        public Outline()
        {
            SubOutlines = new List<Outline>();
        }

        internal Outline Copy()
        {
            return new Outline() 
            {
                text=text,
                desctiption=desctiption,
                title=title,
                SubOutlines = new List<Outline>(SubOutlines)
            };
        }
    }
}
