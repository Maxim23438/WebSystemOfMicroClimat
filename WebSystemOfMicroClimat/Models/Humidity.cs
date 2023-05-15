using System.ComponentModel.DataAnnotations;

namespace WebSystemOfMicroClimat.Models
{
    public class Humidity
    {
        [Key]
        public int Id { get; set; }
        public bool Humidifier { get; set; }
        public bool Fan { get; set; }
        public bool Dehydrator { get; set; }
        public bool Protector { get; set; }
        public bool Regulator { get; set; }
        public bool Hygrometer { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

    }
}
