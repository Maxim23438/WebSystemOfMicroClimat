using System.ComponentModel.DataAnnotations;

namespace WebSystemOfMicroClimat.Models
{
    public class Temp
    {
        [Key]
        public int Id { get; set; }
        public bool Battery { get; set; }
        public bool Kotel { get; set; }
        public bool Bottom { get; set; }
        public bool Kamin { get; set; }
        public bool Obigriv { get; set; }
        public bool Cond { get; set; }
        public bool Lamp { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
