using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemaAPIWrapper.FemaInfo
{
    public class FemaInfo
    {
        public Metadata Metadata { get; set; }
        public IEnumerable<DisasterDeclarationsSummaries> DisasterDeclarationsSummaries { get; set; }

        public IEnumerable<HazardMitigationGrants> HazardMitigationGrants { get; set; }

    }
}
