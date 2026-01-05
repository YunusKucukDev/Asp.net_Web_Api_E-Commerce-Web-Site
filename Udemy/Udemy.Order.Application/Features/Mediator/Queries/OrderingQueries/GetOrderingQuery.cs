using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Order.Application.Features.Mediator.Results.OrderingResults;

namespace Udemy.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingQuery :IRequest<List<GetOrderingQueryResult>>
    {

    }
}
