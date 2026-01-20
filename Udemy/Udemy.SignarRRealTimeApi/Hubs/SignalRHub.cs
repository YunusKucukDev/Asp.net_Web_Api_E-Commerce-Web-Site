using Microsoft.AspNetCore.SignalR;
using Udemy.SignarRRealTimeApi.Services;
using Udemy.SignarRRealTimeApi.Services.SignalRCommentServices;
using Udemy.SignarRRealTimeApi.Services.SignalRMessageServices;

namespace Udemy.SignarRRealTimeApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalRCommentService signalRCommentService;
        private readonly ISignalRMessageService signalRMessageService;

        public SignalRHub(ISignalRCommentService signalRCommentService, ISignalRMessageService signalRMessageService)
        {
            this.signalRCommentService = signalRCommentService;
            this.signalRMessageService = signalRMessageService;
        }

        public async Task SendStatisticCount()
        {
            var getTotalCommentCount = await signalRCommentService.GetTotalCommentCount();
            await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);
           
        }
    }
}
