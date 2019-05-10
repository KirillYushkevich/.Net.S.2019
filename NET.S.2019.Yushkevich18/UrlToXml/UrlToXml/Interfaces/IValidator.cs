using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlToXml.Interfaces
{
    public interface IValidator
    {
        bool Validate(string url);
    }
}
