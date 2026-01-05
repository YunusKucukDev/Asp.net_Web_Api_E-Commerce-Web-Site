using Microsoft.AspNetCore.Mvc;
using Udemy.Cargo.BusinessLayer.absrtact;
using Udemy.Cargo.DtoLayer.Dtos.CargoOperationsDto;
using Udemy.Cargo.EntityLayer.Concrete;

namespace Udemy.Cargo.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {

        private readonly ICargoOperationService _service;

        public CargoOperationController(ICargoOperationService cargoOperationService)
        {
            _service = cargoOperationService;
        }

        [HttpGet]
        public IActionResult GetAllCargoOperation()
        {
            var values = _service.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdCargoOperation(int id)
        {
            var values = _service.TGetById(id);
            return Ok(values);

        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto dto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Barcode = dto.Barcode,
                Description = dto.Description,
                OperationDate = dto.OperationDate,
            };
            _service.TInsert(cargoOperation);
            return Ok("Cargo Operation Başarıyla Oluşturuldu");
        }

        [HttpDelete]
        public IActionResult DeleteByIdCargoOperation(int id)
        {
            _service.TDelete(id);
            return Ok("Cargo Operation Başarıyla Silindi");

        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto dto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                CargoOperationId = dto.CargoOperationId,
                Barcode = dto.Barcode,
                Description = dto.Description,
                OperationDate = dto.OperationDate,
            };
            _service.TUpdate(cargoOperation);
            return Ok("Cargo Operation Başarıyla Güncellendi");
        }






    }
}
