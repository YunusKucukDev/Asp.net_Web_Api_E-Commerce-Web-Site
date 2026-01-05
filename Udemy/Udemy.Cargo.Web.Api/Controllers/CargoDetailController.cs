using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Cargo.BusinessLayer.absrtact;
using Udemy.Cargo.DtoLayer.Dtos.CargoDetailsDto;
using Udemy.Cargo.DtoLayer.Dtos.CargoOperationsDto;
using Udemy.Cargo.EntityLayer.Concrete;

namespace Udemy.Cargo.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {

        private readonly ICargoDetailService _service;

        public CargoDetailController(ICargoDetailService cargoDetailService)
        {
            _service = cargoDetailService;
        }

        [HttpGet]
        public IActionResult GetAllCargoDetail()
        {
            var values = _service.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdCargoDetail(int id)
        {
            var values = _service.TGetById(id);
            return Ok(values);

        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailsDto dto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                Barcode = dto.Barcode,
                SenderCustomer=dto.SenderCustomer,
                ReceiverCustomer=dto.ReceiverCustomer,
                CargoCompanyId=dto.CargoCompanyId,
            };
            _service.TInsert(cargoDetail);
            return Ok("Cargo Detail Başarıyla Oluşturuldu");
        }

        [HttpDelete]
        public IActionResult DeleteByIdCargoDetail(int id)
        {
            _service.TDelete(id);
            return Ok("Cargo Detail Başarıyla Silindi");

        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoDetailsDto dto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                CargoDetailId = dto.CargoDetailId,
                Barcode = dto.Barcode,
                SenderCustomer = dto.SenderCustomer,
                ReceiverCustomer = dto.ReceiverCustomer,
                CargoCompanyId = dto.CargoCompanyId,
            };
            _service.TUpdate(cargoDetail);
            return Ok("Cargo Detail Başarıyla Güncellendi");
        }
    }
}
