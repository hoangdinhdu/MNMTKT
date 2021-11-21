using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Demo.Models {
    public class Category {
        public string CategoryID { get; set; }
        public string CategoryName {get ; set;}
        public ICollection<Product> Products {get; set;}
    }
}