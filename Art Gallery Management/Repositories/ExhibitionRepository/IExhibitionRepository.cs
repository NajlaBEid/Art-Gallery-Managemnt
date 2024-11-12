using Art_Gallery_Management.Models.Exhibitions;

namespace Art_Gallery_Management.Repositories.ExhibitionRepository
{
    public interface IExhibitionRepository
    {
        Exhibition GetExhibitionById(int id);
        Exhibition CreateExhibition(Exhibition exhibition);
        Exhibition UpdateExhibiton (Exhibition exhibition,int id);
        void DeleteExhibition(int id);
    }
}
