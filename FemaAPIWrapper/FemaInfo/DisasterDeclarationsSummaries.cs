using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemaAPIWrapper.FemaInfo
{
    public class DisasterDeclarationsSummaries
    {
        public int DisasterNumber { get; set; }
        public bool IHProgramDeclared { get; set; }
        public bool IAProgramDeclared { get; set; }
        public bool PAProgramDeclared { get; set; }
        public bool HMProgramDeclared { get; set; }
        public string State { get; set; }
        public string DisasterType { get; set; }
        public string IncidentType { get; set; }
        public string Title { get; set; }
        public string IncidentBeginDate { get; set; }
        public string IncidentEndDate { get; set; }
        public string DeclaredCountyArea { get; set; }
        public string Hash { get; set; }
        public string LastRefresh { get; set; }
        public string DisasterCloseOutDate { get; set; }
        public int? PlaceCode { get; set; }
        public string Id { get; set; }



    }
}
