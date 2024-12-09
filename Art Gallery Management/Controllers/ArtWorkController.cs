using Art_Gallery_Management.Models.Artists;
using Art_Gallery_Management.Models.ArtWorks;
using Art_Gallery_Management.Repositories.ArtWorkRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Art_Gallery_Management.Controllers
{
    [Route("api/artwork")]
    [ApiController]
    
    public class ArtWorkController : ControllerBase
    {
        private readonly IArtWorkRepository _repository;
        private readonly IMapper _mapper;

        public ArtWorkController(IArtWorkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetArtWork(int id)
        {

            ArtWork artwork =await _repository.GetArtWorkById(id);
            if (artwork == null)
            {
                return NotFound($"Artwork not found");
            }
            ArtWorkDto artWorkDto = _mapper.Map<ArtWork,ArtWorkDto>(artwork);
            return Ok( artWorkDto);

        }

        [HttpPost]
        public async Task<IActionResult> CreateArtWork(AddArtWork addArtWork)
        {
            ArtWork artWork = _mapper.Map<AddArtWork,ArtWork>(addArtWork);
            ArtWork createdArtWork = await _repository.CreateArtWork(artWork);
            ArtWorkDto artWorkDto = _mapper.Map<ArtWork, ArtWorkDto>(createdArtWork);
            return Ok( artWorkDto);


            //ArtWork artWork = new ArtWork();
            //artWork = _mapper.Map<AddArtWork,ArtWork>(addArtWork);
            //artWork = _repository.CreateArtWork(artWork);
            //ArtWorkDto artWorkDto = _mapper.Map<ArtWork, ArtWorkDto>(artWork);
            //return artWorkDto;
        }


        [HttpPut("updateArtist/{id}")]
        public async Task<IActionResult> UpdateArtWork([FromBody] UpdateArtWork updateArtWork,int id)
        {
          ArtWork  exsistingArtWork = await _repository.GetArtWorkById(id);

            if (exsistingArtWork == null)
            {
                return NotFound($"Artwork not found");
            }
            _mapper.Map(updateArtWork, exsistingArtWork);
            ArtWork artwork = await _repository.UpdateArtWork(exsistingArtWork,id);

            var updatedArtWorkDto = _mapper.Map<ArtWork,ArtWorkDto>(artwork);

            return Ok(updatedArtWorkDto);
                       
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteArtWork(int id) {
            ArtWork exsistingArtWork = await _repository.GetArtWorkById(id);
            if (exsistingArtWork == null)
            {
                return NotFound($"ArtWork with ID {id} not found");
               
            }
            await _repository.DeleteArtWork(exsistingArtWork);
            return Ok($"Artwork with ID:{id} has been deleted successfully");
        }

            
    }
}