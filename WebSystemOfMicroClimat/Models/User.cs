﻿using System.ComponentModel.DataAnnotations;
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

    }
}