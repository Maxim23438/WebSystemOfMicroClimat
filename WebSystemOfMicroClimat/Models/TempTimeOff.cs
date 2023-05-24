namespace WebSystemOfMicroClimat.Models
{
    public class TempTimeOff
    {
        public int Id { get; set; }
        public DateTime? BatteryOff { get; set; }
        public DateTime? KotelOff { get; set; }
        public DateTime? BottomOff { get; set; }
        public DateTime? KaminOff { get; set; }
        public DateTime? ObigrivOff { get; set; }
        public DateTime? CondOff { get; set; }
        public DateTime? LampOff { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
