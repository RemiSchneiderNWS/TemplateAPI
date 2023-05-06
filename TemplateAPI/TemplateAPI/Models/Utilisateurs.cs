using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TemplateAPI.Models
{
    [Table("Utilisateurs")]
    public class Utilisateurs
    {
        [Key] 
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public string password { get; set; }
      

    }
}
