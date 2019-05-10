using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeworkDay11.BooksLoger;
using UrlToXml.Servecies;

namespace UrlToXml
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UrlToXmlService service = new UrlToXmlService(new Converter(), new TxtReader(), new Validator(), new XmlWriter(), new Nloger());
            service.UrlToXML("1.txt", "2.txt");
        }
    }
}
