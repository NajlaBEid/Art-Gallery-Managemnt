using Art_Gallery_Management.Models.Artists;

namespace Art_Gallery_Management.Repositories.ArtistRepository
{
    public interface IArtistRepository
    {
        Artist GetById(int id);
        Artist CreateArtist(Artist artist);
        Artist UpdateArtist(Artist artist, int id);
        void DeleteArtist(int id);
    }
}
