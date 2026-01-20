using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.RabbitMQMessageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        [HttpPost]
        public  IActionResult CreateMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",

            };
            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare("Kuyruk2",false,false,false,null);

            var messageConten = "Merhaba Bu gün hava çok soğuk";

            var byteMessageContetn = Encoding.UTF8.GetBytes(messageConten);

            channel.BasicPublish(exchange: "", routingKey: "Kuyruk2", basicProperties: null, body: byteMessageContetn);

            return Ok("mesajınız kuyruğa alınmıştır");
        }

        private static string message;


        [HttpGet]
        public IActionResult ReadMessage()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("Kuyruk2", false, false, false, null);

            var result = channel.BasicGet("Kuyruk2", autoAck: true);

            if (result == null)
                return NoContent(); // 204 artık mantıklı

            var message = Encoding.UTF8.GetString(result.Body.ToArray());

            return Ok(message);
        }

    }
}
