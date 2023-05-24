namespace WebSystemOfMicroClimat.Models
{
    public class TempTimeOn
    {
        public int Id { get; set; }
        public DateTime? BatteryOn { get; set; }
        public DateTime? KotelOn { get; set;}
        public DateTime? BottomOn { get; set; }
        public DateTime? KaminOn { get; set; }
        public DateTime? ObigrivOn { get; set; }
        public DateTime? CondOn { get; set; }
        public DateTime? LampOn { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
