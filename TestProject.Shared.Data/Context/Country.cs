using System.Collections.Generic;

namespace TestProject.Shared.Data.Context
{
    public class Country : BaseEntity
    {
        public string NameKz { get; set; }
        public string NameRu { get; set; }

        public virtual ICollection<City> Cities { get; private set; } = new HashSet<City>();
    }
}
