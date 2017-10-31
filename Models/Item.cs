using System;

namespace RecruitingAteliware.Models
{
    public class Item
    {
        public int id { get; set; }       
        public string name { get; set; }
        public string description { get; set; }
        public string full_name { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Owner Owner { get; set; }
    }
}