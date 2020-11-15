using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Shared.Data.Models
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string NameKz { get; set; }
        public string NameRu { get; set; }
        public string Bin { get; set; }
    }
}
