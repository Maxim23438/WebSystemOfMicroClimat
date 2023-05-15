using System.ComponentModel.DataAnnotations;

namespace WebSystemOfMicroClimat.Models
{
    public class Light
    {
        [Key]
        public int Id { get; set; }
        public bool Dimmer { get; set; }
        public bool LampLight { get; set; }
        public bool LedLamp { get; set; }
        public bool Curtains { get; set; }
        public bool Jalousie { get; set; }
        public bool Reflector { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
