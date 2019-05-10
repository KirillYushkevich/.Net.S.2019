using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlToXml.Interfaces;

namespace UrlToXml.Servecies
{
    internal class TxtReader : ITxtReadeService
    {
        public IEnumerable<string> ReadFile(string path)
        {
           if(File.Exists(path))
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    string temp;
                    while ((temp = streamReader.ReadLine()) != null)
                    {
                        yield return temp;
                    }
                }
            }
        }
    }
}
