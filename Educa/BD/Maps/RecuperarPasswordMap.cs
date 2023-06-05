using Educa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Educa.BD.Maps
{
    public class RecuperarPasswordMap : IEntityTypeConfiguration<RecuperarPassword>
    {
        public void Configure(EntityTypeBuilder<RecuperarPassword> builder)
        {
            builder.ToTable("RecuperarPassword");
            builder.HasKey(o => o.Id);
        }
    }
}