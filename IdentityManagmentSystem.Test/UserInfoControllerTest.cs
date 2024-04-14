using Application.Contract.Identity;
using Application.Dtos.CommonDtos;
using Application.Models.Abstraction;
using Application.Models.IdentityModels.UserModels;
using Domain.Users;
using IdentityManagmentSystem.API.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using static Application.Features.UserFeatures.Queries.UsersFilterItemsRequestHandlerQuery;

namespace IdentityManagmentSystem.Test
{
    public class UserInfoControllerTest
    {
        private Mock<IMediator> _mediatorMock;
        private Mock<IAuthService> _authServiceMock;
        private UserInfoController _controller;
        public UserInfoControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _authServiceMock = new Mock<IAuthService>();
            _controller = new UserInfoController(_mediatorMock.Object, _authServiceMock.Object);
        }

        [Fact]
        public async Task FilterUsersAsync_ReturnsOkResult_WhenValidInput()
        {
            // Arrange
            var filterDataDto = new FilterDataDto { Filter = "UserName = 'TestUser1'", PageSize = 10, PageIndex = 1 };
            var expectedItems = new List<UserInfoDto>
        {
            new UserInfoDto { Id = "1", UserName = "TestUser1", Email = "test1@example.com", FullName = "Test User 1", PhoneNumber = "09121541949" },
            new UserInfoDto { Id = "2", UserName = "TestUser2", Email = "test2@example.com", FullName = "Test User 2", PhoneNumber = "09190173836" }
        };
            var expectedResponse = new PagedList<UserInfoDto>(expectedItems, 1, 1, 2);
            _mediatorMock.Setup(m => m.Send(It.IsAny<UsersFilterItemsRequestQuery>(), default))
           .ReturnsAsync(expectedResponse);

            var expectedUsers = new List<DomainUser>
             {
            new DomainUser { Id = "1", UserName = "TestUser1", Email = "test1@example.com", FullName = "Test User 1", PhoneNumber = "09121541949" },
            new DomainUser { Id = "2", UserName = "TestUser2", Email = "test2@example.com", FullName = "Test User 2", PhoneNumber = "09190173836" }
             };
            _authServiceMock.Setup(m => m.FilterUserAsync(It.IsAny<FilterData>()))
            .ReturnsAsync(new PagedList<DomainUser>(expectedUsers, 10, 1, 2)
             {
              Paging = new PagingData(10, 1, 2)
             });

            // Act
            var result = await _controller.FilterUsersAsync(filterDataDto);
            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<UserInfoDto>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<UserInfoDto>>(okResult.Value);
            Assert.Equal(expectedItems, model);
        }


    }
}
//public async Task FilterUserAsync__Returns_Correct_Response()
//{
//    // Arrange
//    var expectedItems = new List<UserInfoDto>
//    {
//      new UserInfoDto { Id = "1", UserName = "TestUser" }
//    };
//    var expectedResponse = new PagedList<UserInfoDto>(expectedItems, 10, 1, 1);
//    var filterDataDto = new FilterDataDto { Filter = "Test", PageSize = 10, PageIndex = 1, Sort = "UserName" };
//    _mediatorMock.Setup(m => m.Send(It.IsAny<UsersFilterItemsRequestQuery>(), default))
//        .ReturnsAsync(expectedResponse);

//    // Act
//    var result = await _controller.FilterUsersAsync(filterDataDto);

//    // Assert
//    var actionResult = Assert.IsType<ActionResult<IEnumerable<UserInfoDto>>>(result);
//    var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
//    var model = Assert.IsAssignableFrom<IEnumerable<UserInfoDto>>(okResult.Value);
//    Assert.Equal(expectedItems, model);
//}