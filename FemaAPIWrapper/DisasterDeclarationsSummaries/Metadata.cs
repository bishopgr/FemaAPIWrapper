using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemaAPIWrapper.DisasterDeclarationsSummaries
{
    public class Metadata
    {
        public int Skip { get; set; }
        public int Top { get; set; }
        public string Filter { get; set; }
        public string Format { get; set; }
        public string EntityName { get; set; }
        public string Url { get; set; }


    }
}
