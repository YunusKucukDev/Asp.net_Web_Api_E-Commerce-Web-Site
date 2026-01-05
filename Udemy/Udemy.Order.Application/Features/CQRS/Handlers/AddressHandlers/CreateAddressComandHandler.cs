using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Order.Application.Features.CQRS.Commands.AddressCommands;
using Udemy.Order.Application.Intarfaces;
using Udemy.Order.Domain.Entities;

namespace Udemy.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressComandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressComandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAddressComand createAddressComand)
        {
            await _repository.CreateAsync(new Address
            {
                City = createAddressComand.City,
                Detail = createAddressComand.Detail,
                District = createAddressComand.District,
                UserId = createAddressComand.UserId
            });
        }
    }
}
