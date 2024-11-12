using Art_Gallery_Management.Models.Exhibitions;
using Art_Gallery_Management.Repositories.ExhibitionRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Art_Gallery_Management.Controllers
{
    [Route("api/exhibition")]
    [ApiController]
    public class ExhibitionController : ControllerBase
    {
        private readonly IExhibitionRepository _repository;
        private readonly IMapper _mapper;
        public ExhibitionController(IExhibitionRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public ExhibitionDto GetExhibition(int id)
        {
            Exhibition exhibition = _repository.GetExhibitionById(id);
            ExhibitionDto exhibitionDto = _mapper.Map<Exhibition, ExhibitionDto>(exhibition);
            return exhibitionDto;


        }

        [HttpPost]
        public ExhibitionDto CreateExhibiton(AddExhibition AddExhibition)
        {
            Exhibition exhibition = new Exhibition();
            exhibition = _mapper.Map<AddExhibition, Exhibition>(AddExhibition);
            exhibition = _repository.CreateExhibition(exhibition);
            ExhibitionDto exhibitionDto = _mapper.Map<Exhibition, ExhibitionDto>(exhibition);
            return exhibitionDto;
        }

        [HttpPut]
        public ExhibitionDto UpdateExhibiton(AddExhibition updateExhibition, int id)
        {
            Exhibition exhibition = new Exhibition();
            exhibition = _mapper.Map<AddExhibition, Exhibition>(updateExhibition);
            exhibition = _repository.UpdateExhibiton(exhibition,id);
            ExhibitionDto exhibitionDto = _mapper.Map<Exhibition, ExhibitionDto>(exhibition);
            return exhibitionDto;
        }

        [HttpDelete]
        public string DeleteExhibition(int id)
        {
            _repository.DeleteExhibition(id);
            return "Exhibition with ID: " + id + " has been deleted successfully";

        }
        }
}
