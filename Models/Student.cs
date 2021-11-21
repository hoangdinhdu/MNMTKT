using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
   
    public class Student:Person
    {
        
        public string Address { get; set; }
        public string FullName { get; set; }

        
    }
}