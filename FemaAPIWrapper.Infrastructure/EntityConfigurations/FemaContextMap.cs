using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemaAPIWrapper.Infrastructure.EntityConfigurations
{
    public class FemaContextMap : EntityTypeConfiguration<FemaInfo.DisasterDeclarationsSummaries>
    {
        

        public FemaContextMap()
        {
            ToTable("DisasterDeclarationsSummaries");
        }
    }
}
