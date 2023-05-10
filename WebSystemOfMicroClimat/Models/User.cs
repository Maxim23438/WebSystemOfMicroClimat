using System.ComponentModel.DataAnnotations;

namespace WebSystemOfMicroClimat.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string House { get; set; }
        public string Flat { get; set; }
        public string GreenHouse { get; set; }
        public int ValueId { get; set; }
        public Value Value { get; set; }

    }
}
