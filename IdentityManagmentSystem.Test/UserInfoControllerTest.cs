using Application.Contract.Identity;
using Application.Dtos.CommonDtos;
using Application.Models.Abstraction;
using Application.Models.IdentityModels.UserModels;
using Application.Responses;
using Domain.Users;
using IdentityManagmentSystem.API.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using static Application.Features.UserFeatures.Commands.AddUserRequestHandlerCommand;
using static Application.Features.UserFeatures.Queries.UsersFilterItemsRequestHandlerQuery;

namespace IdentityManagmentSystem.Test
{
    public class UserInfoControllerTest
    {
        private class TestUserDataProvider
        {
            public static FilterDataDto GetFilterDataDto()
            {
                return new FilterDataDto { Filter = "UserName = 'TestUser1'", PageSize = 10, PageIndex = 1 };
            }

            public static List<UserInfoDto> GetExpectedItems()
            {
                return new List<UserInfoDto>
                {
            new UserInfoDto { Id = "1", UserName = "TestUser1", Email = "test1@example.com", FullName = "Test User 1", PhoneNumber = "09121541949" },
            new UserInfoDto { Id = "2", UserName = "TestUser2", Email = "test2@example.com", FullName = "Test User 2", PhoneNumber = "09190173836" }
                };
            }

            public static List<DomainUser> GetExpectedUsers()
            {
                return new List<DomainUser>
                {
            new DomainUser { Id = "1", UserName = "TestUser1", Email = "test1@example.com", FullName = "Test User 1", PhoneNumber = "09121541949" },
            new DomainUser { Id = "2", UserName = "TestUser2", Email = "test2@example.com", FullName = "Test User 2", PhoneNumber = "09190173836" }
                };
            }
        }


        private Mock<IMediator> _mediatorMock;
        private Mock<IAuthService> _authServiceMock;
        private UserInfoController _controller;
        public UserInfoControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _authServiceMock = new Mock<IAuthService>();
            _controller = new UserInfoController(_mediatorMock.Object, _authServiceMock.Object);
            SetupHttpContext();
        }
        private void SetupHttpContext()
        {
            var httpContext = new DefaultHttpContext();
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };
        }

        #region FilterUser
        [Fact]
        public async Task FilterUsersAsync_ReturnsOkResultWithObjects_WhenValidInput()
        {
            // Arrange
            var filterDataDto = TestUserDataProvider.GetFilterDataDto();
            var expectedItems = TestUserDataProvider.GetExpectedItems();
            var expectedResponse = new PagedList<UserInfoDto>(expectedItems, 1, 1, 2);
            _mediatorMock.Setup(m => m.Send(It.IsAny<UsersFilterItemsRequestQuery>(), default))
           .ReturnsAsync(expectedResponse);

            var expectedUsers = TestUserDataProvider.GetExpectedUsers();
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
        #endregion
        #region RegisterUser
        [Fact]
        public async Task RegisterUser_ReturnsOkResult_WhenValidInput()
        {
            // Arrange
            var registrationRequest = new RegistrationRequest 
            {
                UserName = "TestRegUser",
                Email = "testReg@example.com",
                FullName = "Test User Register",
                PhoneNumber = "09190173836"
            
            };
            var expectedResponse = new BaseCommandResponse { Success = true, /* populate other properties as needed */ };

            _mediatorMock.Setup(m => m.Send(It.IsAny<AddUserRequestCommand>(), default))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.RegisterUse(registrationRequest);

            // Assert
            var actionResult = Assert.IsType<ActionResult<BaseCommandResponse>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var model = Assert.IsAssignableFrom<BaseCommandResponse>(okResult.Value);
            Assert.Equal(expectedResponse, model);
        }

        #endregion

    }
}
