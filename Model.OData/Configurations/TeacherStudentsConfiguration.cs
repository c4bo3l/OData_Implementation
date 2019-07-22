using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.OData.Configurations
{
    public class TeacherStudentsConfiguration : IEntityTypeConfiguration<TeacherStudents>
    {
        public void Configure(EntityTypeBuilder<TeacherStudents> builder)
        {
            builder.ToTable(typeof(TeacherStudents).Name);

            builder.HasKey(x => new { x.TeacherId, x.StudentId });

            builder.HasOne(x => x.Student).WithMany(x => x.TeacherStudents).HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.Teacher).WithMany(x => x.TeacherStudents).HasForeignKey(x => x.TeacherId);
        }
    }
}
