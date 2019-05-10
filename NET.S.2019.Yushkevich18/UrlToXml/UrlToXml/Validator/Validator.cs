using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlToXml.Interfaces;

namespace UrlToXml
{
    internal class Validator : IValidator
    {
        public bool Validate(string url) => Uri.IsWellFormedUriString(url, UriKind.Absolute);
    }
}
