using Art_Gallery_Management.Models.Artists;
using Art_Gallery_Management.Models.Exhibitions;

namespace Art_Gallery_Management.Models.ArtWorks
{
    public class ArtWorkDto
    {
        
        public string Name { get; set; } = string.Empty;
        public string Medium { get; set; } = string.Empty;
        public decimal price { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        //One-to-One with Exhibition
        public int ExhibitionId { get; set; } // FK
        public Exhibition Exhibition { get; set; } = null!;

        //One-to-Many with Artist
        public int ArtistId { get; set; } // FK
        public Artist Artist { get; set; } = null!;
    }
}
