using MessageScheduler.Api.Controllers;
using MessageScheduler.Service.Services.Interfaces;
using MessageScheduler.Service.Services.Implementations;
using NUnit.Framework;
using AutoMapper;
using MessageScheduler.Core.Abstactions.Repositories.ReadRepositories;
using MessageScheduler.Core.Abstactions.Repositories.WriteRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MessageScheduler.Data.Repositories.ReadRepositories;
using MessageScheduler.Data.Contexs;
using MessageScheduler.Service.Dtos.MessageDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MessageScheduler.Test.EndPoints
{
    public class MessagesControllerTest
    {
        private readonly IMessageService _messageService;
        MessagesController _messagesController;
        MessagePostDto MessagePostDto;
        public MessagesControllerTest(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [SetUp]
        public void SetUp()
        {
            _messagesController = new MessagesController(_messageService);
            MessagePostDto= new MessagePostDto
            {
                Content="Hello",
                SendAt=DateTime.Now.AddDays(2),
                Method="email",
                To="taghiyev.ahad@gmail.com"
            };
        }

        [Test]
        public async Task Test_Create_Message()
        {
            var result = await _messagesController.Create(MessagePostDto);
            if (result is OkObjectResult okResult)
            {
                Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
                var Message = okResult.Value as MessagePostDto;
                Assert.IsNotNull(Message);
            }
            else if (result is BadRequestObjectResult badRequestResult)
            {
                Assert.AreEqual(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
                var errorMessage = badRequestResult.Value as string;
                Assert.IsNotNull(errorMessage);
            }
            else
            {
                Assert.Fail("Unexpected result");
            }
        }

        [Test]
        public async Task Test_Get_Message()
        {
            var result = await _messagesController.Get(4);
            if (result is OkObjectResult okResult)
            {
                Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
                var Message = okResult.Value as MessagePostDto;
                Assert.IsNotNull(Message);
            }
            else if (result is NotFoundObjectResult notFoundObjectResult)
            {
                Assert.AreEqual(StatusCodes.Status404NotFound, notFoundObjectResult.StatusCode);
                var errorMessage = notFoundObjectResult.Value as string;
                Assert.IsNotNull(errorMessage);
            }
            else
            {
                Assert.Fail("Unexpected result");
            }
        }

        [Test]
        public async Task Test_GetALl_Message()
        {
            var result = await _messagesController.GetMessages();
            if (result is OkObjectResult okResult)
            {
                Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
                var Message = okResult.Value as MessagePostDto;
                Assert.IsNotNull(Message);
            }
            else
            {
                Assert.Fail("Unexpected result");
            }
        }
        [Test]
        public async Task Test_Update_Message()
        {
            var result = await _messagesController.Update(4,MessagePostDto);
            if (result is OkObjectResult okResult)
            {
                Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
                var Message = okResult.Value as MessagePostDto;
                Assert.IsNotNull(Message);
            }
            else if (result is BadRequestObjectResult badRequestResult)
            {
                Assert.AreEqual(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
                var errorMessage = badRequestResult.Value as string;
                Assert.IsNotNull(errorMessage);
            }
            else if (result is NotFoundObjectResult notFoundObjectResult)
            {
                Assert.AreEqual(StatusCodes.Status404NotFound, notFoundObjectResult.StatusCode);
                var errorMessage = notFoundObjectResult.Value as string;
                Assert.IsNotNull(errorMessage);
            }
            else
            {
                Assert.Fail("Unexpected result");
            }
        }

        [Test]
        public async Task Test_RemoveMessage()
        {
            var result = await _messagesController.Get(4);
            if (result is OkObjectResult okResult)
            {
                Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
                var Message = okResult.Value as MessagePostDto;
                Assert.IsNotNull(Message);
            }
            else if (result is NotFoundObjectResult notFoundObjectResult)
            {
                Assert.AreEqual(StatusCodes.Status404NotFound, notFoundObjectResult.StatusCode);
                var errorMessage = notFoundObjectResult.Value as string;
                Assert.IsNotNull(errorMessage);
            }
            else
            {
                Assert.Fail("Unexpected result");
            }
        }
    }
}
