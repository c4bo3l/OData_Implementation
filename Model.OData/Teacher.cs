using System.Collections.Generic;

namespace Model.OData
{
    public class Teacher : BaseEntity
    {
        public ICollection<TeacherStudents> TeacherStudents { get; set; } = new List<TeacherStudents>();
    }
}
