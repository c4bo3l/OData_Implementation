using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.OData.Configurations
{
    public class SchoolConfiguration : BaseConfiguration<School>
    {
        public override void Configure(EntityTypeBuilder<School> builder)
        {
            base.Configure(builder);

            builder.HasMany(x => x.Teachers);
            builder.HasMany(x => x.Students);
        }
    }
}
