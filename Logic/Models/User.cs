﻿namespace Logic.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }
        public string? Email { get; set; }
        public int RoleId { get; set; }
        public int GroupId { get; set; }
        public int Grade { get; set; }
        public long PhoneNumber { get; set; }    
        public int ReadingStreak { get; set; }
        public string? TempKey { get; set; }
    }
}
