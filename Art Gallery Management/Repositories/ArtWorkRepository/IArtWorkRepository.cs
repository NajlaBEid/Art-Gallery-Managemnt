using Art_Gallery_Management.Models.Artists;
using Art_Gallery_Management.Models.ArtWorks;

namespace Art_Gallery_Management.Repositories.ArtWorkRepository
{
    public interface IArtWorkRepository
    {
         Task<ArtWork> GetArtWorkById(int id);
         ArtWork CreateArtWork(ArtWork artwork);
         Task<ArtWork> UpdateArtWork(ArtWork artWork, int id);
        void DeleteArtWork(int id);
    }
}
