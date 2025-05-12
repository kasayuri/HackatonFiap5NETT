using Hackathon.AuthService.Controllers;
using Hackathon.AuthService.Data;
using Hackathon.AuthService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Hackathon.AuthService.Tests;

public class AuthControllerTest
{
    private readonly Mock<AppDbContext> _mockContext;
    private readonly Mock<DbSet<User>> _mockUserSet;
    private readonly AuthController _controller;

    public AuthControllerTest()
    {
        _mockContext = new Mock<AppDbContext>();
        _mockUserSet = new Mock<DbSet<User>>();

        // Setup mock DbSet
        var users = new List<User>().AsQueryable();
        _mockUserSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
        _mockUserSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
        _mockUserSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
        _mockUserSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

        _mockContext.Setup(c => c.Users).Returns(_mockUserSet.Object);

        _controller = new AuthController(_mockContext.Object);
    }

    [Fact]
    public void Register_ShouldAddUserAndSaveChanges()
    {
        // Arrange
        var user = new User { Documento = "123", PasswordHash = "password" };

        // Act
        var result = _controller.Register(user);

        // Assert
        _mockUserSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once);
        _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void Login_ShouldReturnToken_WhenCredentialsAreValid()
    {
        // Arrange
        var hashedPassword = _controller.GetType()
            .GetMethod("Hash", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.Invoke(_controller, new object[] { "password" }) as string;

        var user = new User { Documento = "123", PasswordHash = hashedPassword, Tipo = "Admin" };
        _mockUserSet.Setup(m => m.FirstOrDefault(It.IsAny<System.Linq.Expressions.Expression<System.Func<User, bool>>>()))
            .Returns(user);

        var login = new User { Documento = "123", PasswordHash = "password" };

        // Act
        var result = _controller.Login(login) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Value);
        Assert.Contains("token", result.Value.ToString());
    }

    [Fact]
    public void Login_ShouldReturnUnauthorized_WhenCredentialsAreInvalid()
    {
        // Arrange
        var login = new User { Documento = "123", PasswordHash = "wrongpassword" };

        // Act
        var result = _controller.Login(login);

        // Assert
        Assert.IsType<UnauthorizedObjectResult>(result);
    }
}