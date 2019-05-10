using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace UrlToXml.Interfaces
{
    public interface IConverter
    {
        XElement UrlToXml(IEnumerable<string> urls);
    }
}
