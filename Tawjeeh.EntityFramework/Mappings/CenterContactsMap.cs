using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Tawjeeh.EntityModel;

namespace Tawjeeh.EntityFramework.Mappings
{
    public class CenterContactsMap: EntityTypeConfiguration<CenterContacts>
    {
        public CenterContactsMap()
        {
            HasKey(a => a.Id);            
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);          
            Property(a => a.CenterId).HasColumnType("bigint").IsOptional();            
            Property(a => a.UserId).HasColumnType("bigint").IsOptional();            
            Property(a => a.ContactTypeId).HasColumnType("bigint").IsOptional();
            Property(a => a.IsActive).HasColumnType("bit").IsOptional().HasColumnAnnotation("Default", 1);
            Property(a => a.IsDeleted).HasColumnType("bit").IsOptional().HasColumnAnnotation("Default", 0);
            Property(a => a.CreatedOn).HasColumnType("datetime").IsOptional().HasColumnAnnotation("Default", DateTime.Now);
            Property(a => a.CreatedBy).HasColumnType("bigint").IsOptional();
            Property(a => a.UpdatedOn).HasColumnType("datetime").IsOptional();            
            HasOptional(t => t.ContactType)
              .WithMany(t => t.CenterContacts)
              .HasForeignKey(d => d.ContactTypeId).WillCascadeOnDelete(false);
            HasOptional(t => t.User)
               .WithMany(t => t.CenterContacts)
               .HasForeignKey(d => d.UserId).WillCascadeOnDelete(false);

            HasOptional(t => t.Centers)
             .WithMany(t => t.Contacts)
             .HasForeignKey(d => d.CenterId).WillCascadeOnDelete(false);
            ToTable("tblCenterContacts");
        }
    }
}
