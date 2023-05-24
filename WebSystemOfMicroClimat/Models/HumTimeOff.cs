namespace WebSystemOfMicroClimat.Models
{
    public class HumTimeOff
    {
        public int Id { get; set; }
        public DateTime? HumidifierOff { get; set; }
        public DateTime? FanOff { get; set; }
        public DateTime? DehydratorOff { get; set; }
        public DateTime? ProtectorOff { get; set; }
        public DateTime? RegulatorOff { get; set; }
        public DateTime? HygrometerOff { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
