﻿namespace Logic.Models
{
    public class Message
    {
        public int PostId { get; set; }
        public int GroupId { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
