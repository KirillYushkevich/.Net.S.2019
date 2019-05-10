using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlToXml.Interfaces;

namespace UrlToXml.Servecies
{
    public class UrlToXmlService : IUrlToXmlService
    {
        private IConverter converter;
        private ITxtReadeService reader;
        private IValidator validator;
        private IXmlWriteService writer;
        private ILoger loger;

        public UrlToXmlService(IConverter conv, ITxtReadeService read, IValidator valid, IXmlWriteService write, ILoger log)
        {
            converter = conv;
            reader = read;
            validator = valid;
            writer = write;
            loger = log;
        }

        public void UrlToXML(string inPath, string outPath)
        {
            List<string> urls = reader.ReadFile(inPath).ToList();
            foreach (string s in urls.ToList())
            {
                if (!validator.Validate(s))
                {
                    loger.Warn("not valid uri: " + s);
                    urls.Remove(s);
                }
            }

            writer.XmlToFile(converter.UrlToXml(urls), outPath);
        }
    }
}
