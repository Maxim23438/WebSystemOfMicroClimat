namespace WebSystemOfMicroClimat.Models
{
    public class LightTimeOff
    {
        public int Id { get; set; }
        public DateTime? DimmerOff { get; set; }
        public DateTime? LampLightOff { get; set; }
        public DateTime? LedLampOff { get; set; }
        public DateTime? CurtainsOff { get; set; }
        public DateTime? JalousieOff { get; set; }
        public DateTime? ReflectorOff { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
