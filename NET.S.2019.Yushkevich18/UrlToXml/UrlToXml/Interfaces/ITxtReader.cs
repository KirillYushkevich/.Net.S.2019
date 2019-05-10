using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlToXml.Interfaces
{
    public interface ITxtReadeService
    {
        IEnumerable<string> ReadFile(string path);
    }
}
