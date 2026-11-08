
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceApp.Data.Models
{
    [Table("InsuredPersons")]
    public class InsuredPersonDbModel
    {
        [Key]
        //Tato třída reprezentuje pojištěnou osobu.
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }

        public ICollection<InsuranceDbModel> Insurances { get; set; } = new List<InsuranceDbModel>();
    
        public InsuredPersonDbModel()
        {

        }
    }
}
