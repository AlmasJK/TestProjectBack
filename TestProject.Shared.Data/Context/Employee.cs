using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Shared.Data.Context
{
    public class Employee : BaseEntity
    {
        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string IIN { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        [ForeignKey(nameof(CityId))]
        public Guid CityId { get; set; }
        public City City { get; set; }
    }
}
