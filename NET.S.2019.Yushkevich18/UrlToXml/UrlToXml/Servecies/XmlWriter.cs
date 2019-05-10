using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UrlToXml.Interfaces;

namespace UrlToXml.Servecies
{
    internal class XmlWriter : IXmlWriteService
    {
        public void XmlToFile(XElement xml, string path)
        {
            if(File.Exists(path))
            {
                new XDocument(xml).Save(path);
            }           
        }
    }
}
