namespace Art_Gallery_Management.Models.Exhibitions
{
    public class UpdateExhibition
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;

        //One-to-Many with Manager
        public int ManagerId { get; set; }
    }
}
