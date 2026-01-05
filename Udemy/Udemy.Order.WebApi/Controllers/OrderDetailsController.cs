using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Order.Application.Features.CQRS.Commands.AddressCommands;
using Udemy.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Udemy.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using Udemy.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Udemy.Order.Application.Features.CQRS.Queries.AddressQueries;
using Udemy.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace Udemy.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetOrderDetailQueryCommandHandler _getOrderDetailCommandHandler;
        private readonly GetOrderDetailByIdQueryCommandHandler _getOrderDetailByIdCommandHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailcommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;

        public OrderDetailsController(GetOrderDetailQueryCommandHandler getOrderDetailCommandHandler, GetOrderDetailByIdQueryCommandHandler getOrderDetailByIdCommandHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeOrderDetailcommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler)
        {
            _getOrderDetailCommandHandler = getOrderDetailCommandHandler;
            _getOrderDetailByIdCommandHandler = getOrderDetailByIdCommandHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _removeOrderDetailcommandHandler = removeOrderDetailcommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailsList()
        {
            var values = await _getOrderDetailCommandHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> OrderDetailsById(int id)
        {
            var values = await _getOrderDetailByIdCommandHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(values);

        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetails(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle(command);
            return Ok("Order bilgisi başarılı ile eklendi");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetails(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailCommandHandler.Handle(command);
            return Ok("Order bilgisi başarılı ile güncellendi");

        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrderDetails(int id)
        {
            await _removeOrderDetailcommandHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("Order Başarı ile silindi.");

        }   
    }
}
