using System.Collections.Generic;
using System.Linq;

namespace Model.OData
{
    public class Teacher : BaseEntity
    {
        public ICollection<TeacherStudents> TeacherStudents { get; set; } = new List<TeacherStudents>();

        public ICollection<Student> Students
        {
            get
            {
                return TeacherStudents.Select(x => x.Student).ToList();
            }
        }
    }
}
