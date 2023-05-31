using System.ComponentModel.DataAnnotations;

namespace WebSystemOfMicroClimat.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public int Grade { get; set; }
        public string Desc { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
