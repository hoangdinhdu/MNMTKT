using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    [Table("Persons")]
    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        public string PersomName { get; set; }

        
    }
}
//dotnet-aspnet-codegenerator controller -name StudentsController -m Student -dc MVCDBContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -sqlite