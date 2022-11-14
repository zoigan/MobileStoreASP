using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobileStore.Models;

namespace MobileStore.EntityTypeConfigurations
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(phone=>phone.Id);
            builder.HasIndex(phone=>phone.Id).IsUnique();
        
        }
    }
}
