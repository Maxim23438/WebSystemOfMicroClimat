using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebSystemOfMicroClimat.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public  bool House { get; set; }
        public bool Flat { get; set; }
        public bool GreenHouse { get; set; }
        public Value? Value { get; set; }
        public Temp? Temp { get; set; }
        public Humidity? Humidity { get; set; }
        public Light? Light { get; set; }
        public TempTimeOn? TempTimeOn { get; set; }
        public TempTimeOff? TempTimeOff { get; set; }
        public LightTimeOn? LightTimeOn { get; set; }
        public LightTimeOff? LightTimeOff { get; set; }
        public HumTimeOn? HumTimeOn { get; set; }
        public HumTimeOff? HumTimeOff { get; set; }
        public bool IsPayment { get; set; }
    }
}
