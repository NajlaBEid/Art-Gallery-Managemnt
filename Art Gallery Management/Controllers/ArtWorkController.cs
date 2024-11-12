using Art_Gallery_Management.Models.Artists;
using Art_Gallery_Management.Models.ArtWorks;
using Art_Gallery_Management.Repositories.ArtWorkRepository;
using AutoMapper;
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
        public ArtWorkDto GetArtWork(int id)
        {
            ArtWork artwork = _repository.GetArtWorkById(id);
            ArtWorkDto artWorkDto = _mapper.Map<ArtWork,ArtWorkDto>(artwork);
            return artWorkDto;

        }

        [HttpPost]
        public ArtWorkDto CreateArtWork(AddArtWork addArtWork)
        {
            ArtWork artWork = new ArtWork();
            artWork = _mapper.Map<AddArtWork,ArtWork>(addArtWork);
            artWork = _repository.CreateArtWork(artWork);
            ArtWorkDto artWorkDto = _mapper.Map<ArtWork, ArtWorkDto>(artWork);
            return artWorkDto;
        }
        [HttpPut]
        public ArtWorkDto UpdateArtWork(UpdateArtWork updateArtWork,int id)
        {
            ArtWork artWork = new ArtWork();
            artWork = _mapper.Map<UpdateArtWork, ArtWork>(updateArtWork);
            artWork = _repository.UpdateArtWork(artWork, id);
            ArtWorkDto artWorkDto = _mapper.Map<ArtWork, ArtWorkDto>(artWork);
            return artWorkDto;
        }
        [HttpDelete]
        public string DeleteArtWork(int id) {
            _repository.DeleteArtWork(id);
        return "Artwork with ID: " + id + " has been deleted successfully";
        }

            
    }
}