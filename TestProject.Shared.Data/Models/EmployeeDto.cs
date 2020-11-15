using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Shared.Data.Models
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string IIN { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
    }
}
