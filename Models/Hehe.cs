using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    [Table("Hehes")]
    public class Hehe
    {
        [Key]
        public int HeheID { get; set; }
        public string HeheName { get; set; }        
        
        public string HahaID { get; set; }

        public Haha Haha {get; set;}
    }
}