using Api.Clinic.Enterprise;
using Library.Clinic.DTO;
using Library.Clinic.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Clinic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhysicianController : ControllerBase
    {
        private readonly ILogger<PhysicianController> _logger;

        public PhysicianController(ILogger<PhysicianController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<PhysicianDTO> Get()
        {
            return new PhysicianEC().Physicians;
        }

        [HttpGet("{Physid}")]
        public PhysicianDTO? GetById(int Physid)
        {
            return new PhysicianEC().GetById(Physid);
        }

        [HttpDelete("Delete/{Physid}")]
        public PhysicianDTO? Delete(int Physid)
        {
            return new PhysicianEC().Delete(Physid);
        }
        [HttpPost("Search")]
        public List<PhysicianDTO> Search([FromBody] string q)
        {
            return new PhysicianEC().Search(q?? string.Empty)?.ToList() ?? new List<PhysicianDTO>();
        }

        [HttpPost]
        public Physician? AddOrUpdate([FromBody] PhysicianDTO? physician)
        {
            return new PhysicianEC().AddOrUpdate(physician);
        }
    }
}