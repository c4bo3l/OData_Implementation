using System.Collections.Generic;

namespace Model.OData
{
    public class Student : BaseEntity
    {
        public int Age { get; set; }

        public ICollection<TeacherStudents> TeacherStudents { get; set; } = new List<TeacherStudents>();
    }
}
