using System;

namespace Model.OData
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
