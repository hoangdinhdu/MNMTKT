using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    
    public class Customer:People
    {
       
        public int Adress { get; set; }
        public string PhoneNumber { get; set; }

        
    }
}