using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceApp.Data.Models
{
    public class InsuranceDbModel
    {
        public int Id { get; set; }

        public int InsuredPersonId { get; set; }

        public int InsuranceCategory { get; set; }

        public string? Name { get; set; }

        public string? ContractNumber { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime? ValidTo { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public InsuredPersonDbModel InsuredPerson { get; set; } = null!;
    }
}

