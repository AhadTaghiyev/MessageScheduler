
//using MessageScheduler.Api.Controllers;
//using MessageScheduler.Service.Dtos.MessageDto;
//using MessageScheduler.Service.Services.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using Xunit;

//namespace MessageScheduler.Test.Endpoints
//{
//    internal class MessageControllerTest
//    {
//        private readonly Mock<IMessageService> _mockRepo;
//        private readonly MessagesController _messagesController;
//        private readonly IEnumerable<MessageGetDto> _messageGetDto;

//        public MessageControllerTest(MessagesController messagesController, IEnumerable<MessageGetDto> messageGetDto)
//        {
//            _messagesController = messagesController;
//            _messageGetDto = messageGetDto;
//        }

//        [Fact]
//        public async void GetMessages_ActionExecutes_ReturnOkResultWithMessage()
//        {
//            _mockRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(_messageGetDto);
//            var result = await _messagesController.GetMessages();
          
//            //var okResult = Assert.IsType<OkObjectResult>(result);
//            var returnAdvantage = Assert.IsAssignableFrom<AdvantageListDto>(okResult.Value);
//            Assert.Equal<int>(1, returnAdvantage.AdvantageDtos.ToList().Count());
//        }
//        [Fact]
//        public async void PostAdvantage_ActionExecutes_ReturnCreatedResultWithAdvantage()
//        {
//            _mockRepo.Setup(x => x.AddAsync(advantagePostDto));
//            var result = await _controller.Create(advantagePostDto);
//            var okResult = Assert.IsType<CreatedResult>(result);
//        }
//        [Fact]
//        public async void DeleteAdvantage_ActionExecutes_ReturnNoContentResultWithAdvantage()
//        {
//            _mockRepo.Setup(x => x.Remove(1));
//            var result = _controller.Delete(1);
//            var okResult = Assert.IsType<NoContentResult>(result);
//        }
//        [Fact]
//        public async void GetAdvantage_ActionExecutes_ReturnOkObjectResultWithAdvantage()
//        {
//            _mockRepo.Setup(x => x.GetByIdAsync(true, 1));
//            var result = await _controller.Get(1);
//            var okResult = Assert.IsType<OkObjectResult>(result);
//        }
//        [Fact]
//        public async void UpdateAdvantage_ActionExecutes_NoContentResultWithAdvantage()
//        {
//            _mockRepo.Setup(x => x.Update(advantagePostDto, 1));
//            var result = _controller.Update(advantagePostDto, 1);
//            var okResult = Assert.IsType<NoContentResult>(result);
//        }
//    }
//}
