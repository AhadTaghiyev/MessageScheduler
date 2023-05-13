using MessageScheduler.Service.Dtos.MessageDto;
using MessageScheduler.Service.Services.Implementations;
using MessageScheduler.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MessageScheduler.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IConfiguration _configuration;

        public MessagesController(IMessageService messageService) => _messageService = messageService;

        #region Xml Documentation
        /// <summary>
        /// create message
        /// </summary>
        ///     /// <remarks>
        /// Sample request:
        /// 
        ///     Post /api/v1/Messages/Create
        ///     {
        ///        "to":"taghiyev.ahad@gmail.com/123456",
        ///        "content":"Hello",
        ///        "sendAt":"2023-05-12T20:52:39.484Z",
        ///        "method":"Email/Telegram"
        ///     }
        /// </remarks>
        /// <response code="200">New message created succeffuly</response>
        /// <response code="400">Bad request</response>
        /// <param name="messagePostDto"></param>
        /// <returns></returns>
        #endregion
        [HttpPost("")]
        public async Task<IActionResult> Create(MessagePostDto messagePostDto)
        {
            await _messageService.CreateAsync(messagePostDto);
            return Ok();
        }

      

        #region Xml Documentation
        /// <summary>
        /// get message
        /// </summary>
        ///     /// <remarks>
        /// Sample response:
        /// 
        ///     Get /api/v1/Messages/Get
        ///     {
        ///        "id":"5"
        ///        "to":"taghiyev.ahad@gmail.com/123456",
        ///        "content":"Hello",
        ///        "sendAt":"2023-05-12T20:52:39.484Z",
        ///        "method":"Email/Telegram"
        ///     }
        /// </remarks>
        /// <response code="200">success</response>
        /// <response code="400">bad request</response>
        /// <param name="id"></param>
        /// <returns></returns>
        #endregion
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await _messageService.GetAsync(id));
        }

        #region Xml Documentation
        /// <summary>
        /// get all messages
        /// </summary>
        ///     /// <remarks>
        /// Sample response:
        /// 
        ///     Get /api/v1/Messages/GetMessages
        ///     [
        ///     {
        ///        "id":"5"
        ///        "to":"taghiyev.ahad@gmail.com/123456",
        ///        "content":"Hello",
        ///        "sendAt":"2023-05-12T20:52:39.484Z",
        ///        "method":"Email"
        ///     },
        ///      {
        ///        "id":"6"
        ///        "to":"nagiyev.nicat@gmail.com/123456",
        ///        "content":"Good morning",
        ///        "sendAt":"2023-05-12T20:52:39.484Z",
        ///        "method":"Telegram"
        ///     }
        ///     ]
        /// </remarks>
        /// <response code="200">success</response>
        /// <returns></returns>
        #endregion
        [HttpGet("")]
        public async Task<IActionResult> GetMessages()
        {
            return Ok(await _messageService.GetAllAsync());
        }

        #region Xml Documentation
        /// <summary>
        /// update message
        /// </summary>
        ///     /// <remarks>
        /// Sample request:
        /// 
        ///     Put /api/v1/Messages/Update/3
        ///     {
        ///        "to":"taghiyev.ahad@gmail.com/123456",
        ///        "content":"Hello",
        ///        "sendAt":"2023-05-12T20:52:39.484Z",
        ///        "method":"Email/Telegram"
        ///     }
        /// </remarks>
        /// <response code="200"> message updated succeffuly</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">not found</response>
        /// <param name="id"></param>
        /// <param name="messagePostDto"></param>
        /// <returns></returns>
        #endregion
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] MessagePostDto messagePostDto)
        {
            await _messageService.UpdateAsync(id, messagePostDto);
            return Ok();
        }


        #region Xml Documentation
        /// <summary>
        /// delete message
        /// </summary>
        /// <response code="200"> message deleted succeffuly</response>
        /// <response code="404">not found</response>
        /// <param name="id"></param>
        /// <returns></returns>
        #endregion
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductById([FromRoute] int id)
        {
            await _messageService.DeleteAsync(id);
            return Ok();
        }
    }

}
