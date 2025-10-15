using Microsoft.VisualStudio.TestTools.UnitTesting;
using SignalR_Domains.Interface;
using SignalR_Domains.User;
using SignalR_Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Tests
{
    [TestClass]
    public class UserTest
    {
        private readonly ITokenService _tokenService;

        public UserTest
            (
            ITokenService tokenService
            )
        {
            _tokenService = tokenService;
        }
        public async Task<UserParams> UserAux()
        {
            return new UserParams
            {
                UserName = "testuser",
                Email = "testuser@example.com",
                Password = "Password123",
                AvatarUrl = "http://example.com/avatar.jpg",
                Description = "Test user",
                TimeZoneOffset = 0,
                IsActive = true
            };
        }

        [TestMethod]
        public async Task TestCreateUser_Success()
        {
            var userParams = await UserAux();
            var result = await User.Create(userParams);
            Assert.IsNotNull(result);
            Assert.AreEqual("testuser", result.UserName);
            Assert.AreEqual(userParams.Email, result.Email);
            Assert.AreEqual(userParams.AvatarUrl, result.AvatarUrl);
            Assert.AreEqual(userParams.Description, result.Description);
            Assert.AreEqual(userParams.TimeZoneOffset, result.TimeZoneOffset);
            Assert.AreEqual(userParams.IsActive, result.IsActive);
        }

        [TestMethod]
        public async Task TestUpdateUser_Success()
        {
            var originalUserParams = await UserAux();
            var userParams = new UserParams
            {
                UserName = "testuser2",
                Email = "teste2@user.com"
            };
            var result = await User.Create(originalUserParams);
            
            var updatedUser = await User.Update(result, userParams);

            Assert.AreEqual("testuser2", updatedUser.UserName);
            Assert.AreEqual(userParams.Email, updatedUser.Email);
        }

        [TestMethod]
        public async Task TestCreateUser_Failure() 
        {
            var invalidParams = new UserParams
            {
                UserName = "",
                Email = "",    
                Password = ""  
            };

            try
            {
                await User.Create(invalidParams);
                Assert.Fail("Expected ErrorLists exception was not thrown.");
            }
            catch (ErrorLists ex)
            {
                foreach (var error in ex.Errors)
                {
                    Console.WriteLine(error);
                }
            }
        }

        [TestMethod]
        public async Task CreateTokenSucess()
        {
            var user = await User.Create(await UserAux());
            Console.WriteLine(user.Id);
            var token = _tokenService.GenerateToken(user);
            Assert.IsNotNull(token);
            Assert.IsInstanceOfType(token, typeof(string));

        }
    }
}
