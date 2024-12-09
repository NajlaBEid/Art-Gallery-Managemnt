using Art_Gallery_Management.Models.Exhibitions;

namespace Art_Gallery_Management.Repositories.ExhibitionRepository
{
    public interface IExhibitionRepository
    {
        Task<Exhibition> GetExhibitionById(int id);
        Task<Exhibition> CreateExhibition(Exhibition exhibition);
        Task<Exhibition> UpdateExhibiton (Exhibition exhibition,int id);
        Task<Exhibition> DeleteExhibition(Exhibition exhibition);
    }
}
