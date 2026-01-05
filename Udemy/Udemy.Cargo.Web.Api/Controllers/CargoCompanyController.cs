using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Cargo.BusinessLayer.absrtact;
using Udemy.Cargo.DtoLayer.Dtos.CargoCompanyDto;
using Udemy.Cargo.EntityLayer.Concrete;

namespace Udemy.Cargo.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {

        private readonly ICargoCompanyservice _service;

        public CargoCompanyController(ICargoCompanyservice service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _service.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdCargoCompanyList(int id)
        {
            var values = _service.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargocompanyDto dto)
        {
            CargoCompany company = new CargoCompany()
            {
                CargoCompanyName = dto.CargoCompanyName
            };
            _service.TInsert(company);
            return Ok("Cargo irketi başarıyla oluşturuldu");

        }

        [HttpDelete]
        public IActionResult RemoveCompanyName(int id)
        {
            _service.TDelete(id);
            return Ok("Kargo Şirketi Başarıyla Silindi.");
        }

        [HttpPut]
        public IActionResult UpdateCompanyName(UpdateCargoCompanyDto dto)
        {
            CargoCompany company = new CargoCompany()
            {
                CargoCompanyID = dto.CargoCompanyID,
                CargoCompanyName = dto.CargoCompanyName
            };
            _service.TUpdate(company);
            return Ok("Kargo Şirketi Başarıyla Güncellendi");

        }
    }
}
