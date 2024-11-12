namespace Art_Gallery_Management.Models.ArtWorks
{
    public class UpdateArtWork
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Medium { get; set; } = string.Empty;
        public decimal price { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        //One-to-One with Exhibition
        public int ExhibitionId { get; set; } // FK

        //One-to-Many with Artist
        public int ArtistId { get; set; } // FK
    }
}
