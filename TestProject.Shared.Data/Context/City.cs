using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Shared.Data.Context
{
    public class City : BaseEntity
    {
        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }
        public Guid CountryId { get; set; }
        public string NameKz { get; set; }
        public string NameRu { get; set; }
    }
}
