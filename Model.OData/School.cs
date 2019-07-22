using System.Collections.Generic;

namespace Model.OData
{
    public class School : BaseEntity
    {
        public ICollection<Student> Students { get; set; } = new List<Student>();

        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
