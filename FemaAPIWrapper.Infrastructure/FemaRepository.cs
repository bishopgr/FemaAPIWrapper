using FemaAPIWrapper.FemaInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemaAPIWrapper.Infrastructure
{
    public class FemaRepository
    {
        FemaContext femaContext = new FemaContext();
        public FemaRepository()
        {
            
        }

        public void Insert(DisasterDeclarationsSummaries disasterDeclarationsSummaries)
        {
            femaContext.DisasterDeclarationSummaries.Add(disasterDeclarationsSummaries);
            femaContext.SaveChanges();
        }

        public void InsertAll(IEnumerable<DisasterDeclarationsSummaries> disasterDeclarationsSummaries)
        {
            femaContext.DisasterDeclarationSummaries.AddRange(disasterDeclarationsSummaries);
            femaContext.SaveChanges();
        }
    }
}
