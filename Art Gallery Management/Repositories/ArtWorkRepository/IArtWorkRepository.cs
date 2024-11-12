using Art_Gallery_Management.Models.Artists;
using Art_Gallery_Management.Models.ArtWorks;

namespace Art_Gallery_Management.Repositories.ArtWorkRepository
{
    public interface IArtWorkRepository
    {
        ArtWork GetArtWorkById(int id);
        ArtWork CreateArtWork(ArtWork artist);
        ArtWork UpdateArtWork(ArtWork artist, int id);
        void DeleteArtWork(int id);
    }
}
