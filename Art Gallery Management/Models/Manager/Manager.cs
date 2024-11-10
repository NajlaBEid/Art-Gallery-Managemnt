using Art_Gallery_Management.Models.Exhibitions;
using System.ComponentModel.DataAnnotations;

namespace Art_Gallery_Management.Models.Managers
{
    public class Manager
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumebr { get; set; } = string.Empty;

        // One-to-Many with Exhibition
        public ICollection<Exhibition> exhibitions { get; } = new List<Exhibition>();


    }
}
