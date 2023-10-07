using MediatR;
using Microsoft.AspNetCore.Mvc;
using N5Challenge.Api;
using N5Challenge.Api.Controllers;
using N5Challenge.Domain.Commands;
using N5Challenge.Domain.Models;
using N5Challenge.Domain.Queries;

namespace N5_Challenge.Test
{
    public class UnitTest
    {
        private Mock<IMediator> _mediator;
        private PermissionController _permissionController;

        [SetUp]
        public void Setup()
        {
            _mediator = new Mock<IMediator>();
            _permissionController = new PermissionController(_mediator.Object);
        }

        [Test]
        public async Task Get()
        {
            var permissions = new List<Permission>
            {
                new Permission { },
            };

            _mediator.Setup(m => m.Send(It.IsAny<GetPermissions>(), default)).ReturnsAsync(permissions);

            var result = await _permissionController.Get();

            Assert.IsNotNull(result);
            Assert.That(permissions.Count == result?.Count());
        }

        [Test]
        public async Task GetPermissionById()
        {
            int permissionId = 1;
            var permission = new Permission
            {
                Id = permissionId
            };

            _mediator.Setup(m => m.Send(It.IsAny<GetPermissionById>(), default)).ReturnsAsync(permission);

            var result = await _permissionController.GetPermissionById(permissionId);

            Assert.IsNotNull(result);
            Assert.That(result.Id == permissionId);
        }

        [Test]
        public async Task ModifyPermission()
        {
            var permissionDto = new PermissionDto() { Id = 1, Name = "Juan", Surname = "Perez" };
            _mediator.Setup(m => m.Send(It.IsAny<UpdatePermission>(), default));

            var result = await _permissionController.ModifyPermission(permissionDto);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkResult>(result);
        }
    }
}