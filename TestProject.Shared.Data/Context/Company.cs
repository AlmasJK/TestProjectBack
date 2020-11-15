using System;
using System.Collections.Generic;

namespace TestProject.Shared.Data.Context
{
    public class Company : BaseEntity
    {
        public string NameKz { get; set; }
        public string NameRu { get; set; }
        public string Bin { get; set; }
        public virtual ICollection<Employee> Employees { get; private set; } = new HashSet<Employee>();
    }
}
