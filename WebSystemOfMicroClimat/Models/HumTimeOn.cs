namespace WebSystemOfMicroClimat.Models
{
    public class HumTimeOn
    {
        public int Id { get; set; }
        public DateTime? HumidifierOn { get; set; }
        public DateTime? FanOn { get; set; }
        public DateTime? DehydratorOn { get; set; }
        public DateTime? ProtectorOn { get; set; }
        public DateTime? RegulatorOn { get; set; }
        public DateTime? HygrometerOn { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
