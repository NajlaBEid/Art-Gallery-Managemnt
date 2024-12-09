using Art_Gallery_Management.Data;
using Art_Gallery_Management.Models.Artists;
using Art_Gallery_Management.Repositories.ArtistRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Art_Gallery_Management.Controllers
{
    [Route("api/artist")]
    [ApiController]
    [Authorize]
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
        public async Task<IActionResult> GetArtistById(int id)
        {
            Artist artist = await _repository.GetById(id);
            ArtistDto artistDto = _mapper.Map<Artist,ArtistDto>(artist);
            return Ok(artistDto);

        }
        [HttpPost("createArtist")]
        public async Task<IActionResult> CreateArtist(AddArtist addArtist)
        {
            Artist artist = _mapper.Map<AddArtist, Artist>(addArtist);
            Artist createdArtist = await _repository.CreateArtist(artist);
            ArtistDto artistDto = _mapper.Map<Artist, ArtistDto>(createdArtist);
            return Ok(artistDto);
            //Artist newArtist = new Artist();
            //newArtist = _mapper.Map<Artist>(addArtist);
            //newArtist = _repository.CreateArtist(newArtist);
            //ArtistDto artistDto = _mapper.Map<Artist,ArtistDto>(newArtist);
            //return artistDto;
        }

        [HttpPut ("updateArtist/{id}")]
        public async Task<IActionResult> UpdateArtist([FromBody]UpdateArtist updateArtist, int id)
        {

            Artist exsistingArtist = await _repository.GetById(id);
            if (exsistingArtist == null)
            {
                return NotFound($"Artwork not found");
            }
            _mapper.Map(updateArtist, exsistingArtist);

             Artist artist = await _repository.UpdateArtist(exsistingArtist, id);
            var updateArtistDto = _mapper.Map<Artist, ArtistDto>(artist);
            return Ok(updateArtistDto);


            //Artist newArtist = new Artist();
            //newArtist = _mapper.Map<UpdateArtist,Artist>(updateArtist);
            //Artist updatedArtist = _repository.UpdateArtist(newArtist, id);
            //ArtistDto artistDto = _mapper.Map<Artist,ArtistDto>(newArtist);
            //return artistDto;
        }

        [HttpDelete("deleteArtist/{id}")]
        public async Task<IActionResult> DeleteArtist (int id)
        {
            Artist artist = await _repository.GetById(id);
            if(artist == null)
            {
                return NotFound($"Artist with ID {id} not found");
            }
            await _repository.DeleteArtist(artist);
            return Ok($"Artist with ID:{id} has been deleted successfully");
        }   



    }
}


//ArtWork artWork = await _repository.GetArtWorkById(id);
//if (artWork == null)
//{
//    return NotFound($"ArtWork with ID {id} not found");

//}
//await _repository.DeleteArtWork(artWork);
//return Ok($"Artwork with ID:{id} has been deleted successfully");
//        }
