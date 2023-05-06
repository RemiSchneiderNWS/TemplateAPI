using System.ComponentModel.DataAnnotations;

namespace TemplateAPI.Models
{
    public class Objet
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int nombre { get; set; }
    }
}
