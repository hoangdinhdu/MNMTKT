using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Demo.Models {
    public class Haha {
        public string HahaID { get; set; }
        public string HahaName {get ; set;}
        public ICollection<Hehe> Hehes {get; set;}
    }
}