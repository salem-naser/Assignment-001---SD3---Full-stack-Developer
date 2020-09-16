using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Task.Domain
{
    public class UserAdressMap
    {
        public UserAdressMap(EntityTypeBuilder<Adress> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.City).IsRequired();
            entityBuilder.Property(t => t.Governrate).IsRequired();
            entityBuilder.Property(t => t.Street);
        }
    }
}
