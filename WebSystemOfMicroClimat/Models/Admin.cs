using System.ComponentModel.DataAnnotations;

namespace WebSystemOfMicroClimat.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
