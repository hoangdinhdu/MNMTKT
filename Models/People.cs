using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    [Table("People")]
    public class People
    {
        [Key]
        public int PeopleID { get; set; }
        public string PeopleName { get; set; }

        
    }
}