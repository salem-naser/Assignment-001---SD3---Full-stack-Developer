using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Task.Domain
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {

            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Email).IsRequired();
            entityBuilder.Property(t => t.FirstName).IsRequired();
            entityBuilder.Property(t => t.BirthDate).IsRequired();
            entityBuilder.Property(t => t.MiddleName).IsRequired();
            entityBuilder.Property(t => t.LasTName).IsRequired();

            entityBuilder.HasOne(t => t.Adress).WithOne(u => u.User).HasForeignKey<Adress>(x => x.Id);
        }
    }
}
