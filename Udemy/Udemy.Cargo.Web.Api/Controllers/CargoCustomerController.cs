using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Cargo.BusinessLayer.absrtact;
using Udemy.Cargo.BusinessLayer.concrete;
using Udemy.Cargo.DtoLayer.Dtos.NewFolder;
using Udemy.Cargo.EntityLayer.Concrete;

namespace Udemy.Cargo.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _service;

        public CargoCustomerController(ICargoCustomerService service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult GetAllCargoCustomer()
        {
            var values = _service.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetByİdCargoCustomer(int id)
        {
            var values = _service.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargocustomerDto dto)
        {
            Cargocustomer cargoCustomer = new Cargocustomer()
            {
                Address = dto.Address,
                City=dto.City,
                Districk=dto.Districk,
                Email=dto.Email,    
                Name=dto.Name,
                Phone= dto.Phone,
                Surname=dto.Surname,
            };
            _service.TInsert(cargoCustomer);
            return Ok("Cargo Customer Başarıyla oluşturuldu");
        }

        [HttpDelete]
        public IActionResult DeleteCargoCustomer(int id)
        {
             _service.TDelete(id);
            return Ok("Cargo Customer Silme İşlemi başarılı.");
        }

        [HttpPost]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto dto)
        {
            Cargocustomer customer = new Cargocustomer()
            {
                Address=dto.Address,
                CargocustomerId=dto.CargocustomerId,
                City= dto.City,
                Districk= dto.Districk,
                Email=dto.Email,
                Name=dto.Name,
                Phone=dto.Phone,    
                Surname=dto.Surname,
            };
            _service.TUpdate(customer);
            return Ok("Güncelleme işlemi başarılı");
        }

    }
}
