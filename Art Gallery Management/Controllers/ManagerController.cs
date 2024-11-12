using Art_Gallery_Management.Models.Managers;
using Art_Gallery_Management.Repositories.ManagerRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Extensibility;

namespace Art_Gallery_Management.Controllers
{
    [Route("api/manager")]
    [ApiController]
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
        public ManagerDto CreateManager(int id)
        {
            Manager manager = _repository.GetManagerById(id);
            ManagerDto managerDto = _mapper.Map<Manager, ManagerDto>(manager);
            return managerDto;


        }

        [HttpPost]
        public ManagerDto CreateManager(AddManager addManager)
        {
            Manager manager = new Manager();
            manager = _mapper.Map<AddManager, Manager>(addManager);
            manager = _repository.CreateManager(manager);
            ManagerDto managerDto = _mapper.Map<Manager, ManagerDto>(manager);
            return managerDto;

        }
        [HttpPut]
        public ManagerDto UpdateManager(AddManager addManager, int id)
        {
            Manager manager = new Manager();
            manager = _mapper.Map<AddManager, Manager>(addManager);
            manager = _repository.UpdateManager(manager, id);
            ManagerDto managerDto = _mapper.Map<Manager, ManagerDto>(manager);
            return managerDto;

        }

        [HttpDelete]
        public string DeleteManager(int id)
        {
            _repository.DeleteManager(id);
            return "Manager with ID: " + id + " has been deleted successfully";

        }
    }
}
