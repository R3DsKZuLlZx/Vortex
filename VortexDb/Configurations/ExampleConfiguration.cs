using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VortexDb.Entities;

namespace VortexDb.Configurations;

public class ExampleConfiguration : IEntityTypeConfiguration<Example>
{
    public void Configure(EntityTypeBuilder<Example> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
