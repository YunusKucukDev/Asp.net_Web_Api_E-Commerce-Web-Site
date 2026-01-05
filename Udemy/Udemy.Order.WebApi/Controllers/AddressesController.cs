using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Order.Application.Features.CQRS.Commands.AddressCommands;
using Udemy.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using Udemy.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace Udemy.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly CreateAddressComandHandler _createAddressComandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressComandHandler;
        private readonly RemoveAddressCommandHandler _removeAddressComandHandler;

        public AddressesController(GetAddressQueryHandler getAddressQueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, CreateAddressComandHandler createAddressComandHandler, UpdateAddressCommandHandler updateAddressComandHandler, RemoveAddressCommandHandler removeAddressComandHandler)
        {
            _getAddressQueryHandler = getAddressQueryHandler;
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _createAddressComandHandler = createAddressComandHandler;
            _updateAddressComandHandler = updateAddressComandHandler;
            _removeAddressComandHandler = removeAddressComandHandler;
        }

        [HttpGet] 
        public async Task<IActionResult> AddressList()
        {
            var values = await _getAddressQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> AddressListById(int id)
        {
            var values = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(values);

        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressComand command)
        {
            await _createAddressComandHandler.Handle(command);
            return Ok("Address bilgisi başarılı ile eklendi");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            await _updateAddressComandHandler.Handle(command);
            return Ok("Address bilgisi başarılı ile güncellendi");

        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            await _removeAddressComandHandler.Handle(new RemoveAddressCommand(id));
            return Ok("Adres Başarı ile silindi.");

        }
    }
}
