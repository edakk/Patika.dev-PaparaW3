
using System.ComponentModel.DataAnnotations.Schema;

namespace PaparaThirdWeek.Domain.Entities
{
    [Table("Employees")]
   public class Employee:BaseEntity
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string TaxNumber { get; set; }
        public string Email { get; set; }

    }
}
