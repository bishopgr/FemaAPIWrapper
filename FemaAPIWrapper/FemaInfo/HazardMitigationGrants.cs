using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemaAPIWrapper.FemaInfo
{
    public class HazardMitigationGrants
    {
        public Metadata Metadata { get; set; }

        public int Region { get; set; }
        public string State { get; set; }
        public int DisasterNumber { get; set; }
        public string DeclarationDate { get; set; }
        public string IncidentType { get; set; }
        public string DisasterTitle { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectType { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectCounties { get; set; }
        public string Status { get; set; }
        public string Subgrantee { get; set; }
        public int SubgranteeFIPSCode { get; set; }
        public int ProjectAmount { get; set; }
        public int CostSharePercentage { get; set; }
        public string Hash { get; set; }
        public string LastRefresh { get; set; }
        public string Id { get; set; }

    }
}
