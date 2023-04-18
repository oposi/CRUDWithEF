using System.ComponentModel.DataAnnotations;

namespace CRUDWithEF
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(255)]
        public string Dob { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
    }
}
