using Art_Gallery_Management.Models.Exhibitions;
using Art_Gallery_Management.Repositories.ExhibitionRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Art_Gallery_Management.Controllers
{
    [Route("api/exhibition")]
    [ApiController]
    //[Authorize]
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
        public async Task<IActionResult> GetExhibition(int id)
        {
            Exhibition exhibition = await _repository.GetExhibitionById(id);
            ExhibitionDto exhibitionDto = _mapper.Map<Exhibition, ExhibitionDto>(exhibition);
            return Ok(exhibitionDto);


        }

        [HttpPost]
        public async Task<IActionResult> CreateExhibiton(AddExhibition AddExhibition)
        {
            Exhibition exhibition = _mapper.Map<AddExhibition, Exhibition>(AddExhibition);
            Exhibition createdExhibition = await _repository.CreateExhibition(exhibition);
            ExhibitionDto exhibitionDto = _mapper.Map<Exhibition, ExhibitionDto>(createdExhibition);
            return Ok(exhibitionDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExhibiton(UpdateExhibition updateExhibition, int id)
        {
            Exhibition exsistingExhibition = await _repository.GetExhibitionById(id);
            if(exsistingExhibition == null)
            {
                return NotFound($"Exhibition not found");
            }

            _mapper.Map(updateExhibition, exsistingExhibition);
            Exhibition exhibition = await _repository.UpdateExhibiton(exsistingExhibition, id);
            var exhibitionDto = _mapper.Map<Exhibition, ExhibitionDto>(exhibition);
 
            return Ok(exhibitionDto) ;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteExhibition(int id)
        {
            Exhibition exhibition = await _repository.GetExhibitionById(id);
            if(exhibition == null)
            {
                return NotFound($"Exhibition not found");

            }
            await _repository.DeleteExhibition(exhibition);
            return Ok($"Exhibition with ID: {id} has been deleted successfully");
           
        }
        }
}
