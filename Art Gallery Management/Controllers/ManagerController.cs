using Art_Gallery_Management.Models.Managers;
using Art_Gallery_Management.Repositories.ManagerRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensibility;

namespace Art_Gallery_Management.Controllers
{
    [Route("api/manager")]
    [ApiController]
    //[Authorize]
    public class ManagerController : ControllerBase
    {

        private readonly IManagerRepository _repository;
        private readonly IMapper _mapper;

        public ManagerController(IManagerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CreateManager(int id)
        {
            Manager manager = await _repository.GetManagerById(id);
            ManagerDto managerDto = _mapper.Map<Manager, ManagerDto>(manager);
            return Ok(managerDto);

        }
            [HttpPost]
            public async Task<IActionResult> CreateManager(AddManager addManager)
            {
                Manager manager = _mapper.Map<AddManager, Manager>(addManager);
                Manager createManager = await _repository.CreateManager(manager);
                ManagerDto managerDto = _mapper.Map<Manager, ManagerDto>(manager);
                return Ok(managerDto);

            }
            [HttpPut]
            public  async Task<IActionResult> UpdateManager(UpdateManager updateManager, int id)
            {
                Manager exsistingManager = await _repository.GetManagerById(id);
            if (exsistingManager == null)
            {
                return NotFound($"Manager not found");
            }
                _mapper.Map(updateManager,exsistingManager);
                Manager manager = await _repository.UpdateManager(exsistingManager, id);
                ManagerDto managerDto = _mapper.Map<Manager, ManagerDto>(manager);
                return Ok(managerDto);

            }

            [HttpDelete]
            public async Task<IActionResult> DeleteManager(int id)
            {
            Manager exsistingManager = await _repository.GetManagerById(id);
            if (exsistingManager == null)
            {
                return NotFound($"Manager not found");
            }
            await _repository.DeleteManager(exsistingManager);
                return Ok($"Manager with ID: " + id + " has been deleted successfully");

            }
        }
    }
    
