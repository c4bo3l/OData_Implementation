using System;

namespace Model.OData
{
    public class TeacherStudents
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
