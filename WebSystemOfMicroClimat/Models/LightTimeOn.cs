namespace WebSystemOfMicroClimat.Models
{
    public class LightTimeOn
    {
        public int Id { get; set; }
        public DateTime? DimmerOn { get; set; }
        public DateTime? LampLightOn { get; set; }
        public DateTime? LedLampOn { get; set; }
        public DateTime? CurtainsOn { get; set; }
        public DateTime? JalousieOn { get; set; }
        public DateTime? ReflectorOn { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
