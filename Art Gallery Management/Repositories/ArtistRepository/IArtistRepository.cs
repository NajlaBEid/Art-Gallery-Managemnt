using Art_Gallery_Management.Models.Artists;

namespace Art_Gallery_Management.Repositories.ArtistRepository
{
    public interface IArtistRepository
    {
        Task<Artist> GetById(int id);
        Task<Artist> CreateArtist(Artist artist);
        Task<Artist> UpdateArtist(Artist artist, int id);
        Task<Artist> DeleteArtist(Artist id);
    }
}
