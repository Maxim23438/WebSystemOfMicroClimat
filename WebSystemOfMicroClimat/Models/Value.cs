using System.ComponentModel.DataAnnotations;

namespace WebSystemOfMicroClimat.Models
{
    public class Value
    {
        [Key]
        public int ValueID { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int Light { get; set; }
        public int UserId { get; set; }
        public User? User {  get; set; }
    }
}
