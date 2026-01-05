using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Order.Application.Features.Mediator.Commands.OrderingCommands
{
    public class RemoveOrderingCommand :IRequest<Unit>
    {
        public int Id { get; set; }

        public RemoveOrderingCommand(int id)
        {
            Id = id;
        }
    }
}
