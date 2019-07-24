using System.Collections.Generic;
using System.Linq;

namespace Model.OData
{
    public class Student : BaseEntity
    {
        public int Age { get; set; }

        public ICollection<TeacherStudents> TeacherStudents { get; set; } = new List<TeacherStudents>();

        public ICollection<Teacher> Teachers
        {
            get
            {
                return TeacherStudents.Select(x => x.Teacher).ToList();
            }
        }
    }
}
