using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using UrlToXml.Interfaces;

namespace UrlToXml.Servecies
{
    internal class Converter : IConverter
    {
        public XElement UrlToXml(IEnumerable<string> urls)
        {
            return new XElement(
                "urlAdress", 
                urls.Select(url =>
            {
                Uri.TryCreate(url, UriKind.Absolute, out Uri uri);
                return UrlToXelem(uri);
            }));
        }

        private XElement UrlToXelem(Uri url)
        {
            return new XElement("urlAdress", new XElement("host", new XAttribute("name", url.Host)), GetSegments(url.Segments), GetParameters(url.Query));
        }

        private XElement GetSegments(string[] seg)
        {
            if (seg.Length > 1)
            {
                return new XElement("uri", seg.Skip(1).Select(segm => new XElement("segment", segm.Replace("/", string.Empty))));
            }

            return null;
        }

        private XElement GetParameters(string q)
        {
            if (q.Length > 0)
            {
                return new XElement(
                    "parameters",
                    q.Substring(1).Split('&')
                    .Select(p =>
                    {
                        int index = p.IndexOf('=');
                        string key = p.Substring(0, index);
                        string value = p.Substring(index + 1);
                        return new XElement("parameter", new XAttribute("value", value), new XAttribute("key", key));
                    }));
            }

            return null;
        }
    }
}
