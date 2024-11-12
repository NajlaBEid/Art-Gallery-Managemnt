using Art_Gallery_Management.Data;
using Art_Gallery_Management.Models.Artists;
using Art_Gallery_Management.Repositories.ArtistRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Art_Gallery_Management.Controllers
{
    [Route("api/artist")]
    [ApiController]
    public class ArtistController : ControllerBase
    {

        private readonly IArtistRepository _repository;
        private readonly IMapper _mapper;

        
        public ArtistController(IArtistRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet("getArtist/{id}")]
        public ArtistDto GetArtistById(int id)
        {
            Artist artist = _repository.GetById(id);
            ArtistDto artistDto = _mapper.Map<Artist,ArtistDto>(artist);
            return artistDto;

        }
        [HttpPost("createArtist")]
        public ArtistDto CreateArtist(AddArtist addArtist)
        {
            Artist newArtist = new Artist();
            newArtist = _mapper.Map<Artist>(addArtist);
            newArtist = _repository.CreateArtist(newArtist);
            ArtistDto artistDto = _mapper.Map<Artist,ArtistDto>(newArtist);
            return artistDto;
        }

        [HttpPut ("updateArtist/{id}")]
        public ArtistDto UpdateArtist(UpdateArtist updateArtist, int id)
        {
            Artist newArtist = new Artist();
            newArtist = _mapper.Map<UpdateArtist,Artist>(updateArtist);
            Artist updatedArtist = _repository.UpdateArtist(newArtist, id);
            ArtistDto artistDto = _mapper.Map<Artist,ArtistDto>(newArtist);
            return artistDto;
        }

        [HttpDelete("deleteArtist/{id}")]
        public string DeleteArtist (int id)
        {
            _repository.DeleteArtist(id);
            return "Artist with ID: " + id + " has been deleted successfully";

        }   



    }
}
