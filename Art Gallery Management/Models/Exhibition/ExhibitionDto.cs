using Art_Gallery_Management.Models.ArtWorks;
using Art_Gallery_Management.Models.Managers;

namespace Art_Gallery_Management.Models.Exhibitions
{
    public class ExhibitionDto
    {
    
        public string Title { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;

        //One-to-Many with Manager
        public int ManagerId { get; set; }
        public Manager Manager { get; set; } = null!;

        //One-to-One with ArtWork
        public ArtWork? artWork { get; set; }
    }
}
