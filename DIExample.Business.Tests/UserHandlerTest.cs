using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DIExample.Business;
using Moq;

namespace DIExample.Business.Tests
{
    [TestFixture]
    class UserHandlerTest
    {
        [Test, ExpectedException(typeof(InvalidUser))]
        public void throws_exception_when_adding_user_without_username()
        {
            var logger = new Mock<IUserLogger>();
            var handler = new UserHandler(logger.Object);

            var invalidUser = new User
            {
                UserName = "",
                Email = "example@exaple.com"
            };

            handler.Save(invalidUser);
        }

        [Test]
        public void logs_valid_user()
        {
            var logger = new Mock<IUserLogger>();

            var handler = new UserHandler(logger.Object);

            var user = new User()
            {
                UserName = "Jim",
                Email = "jiim.aho@gmail.com"
            };

            handler.Save(user);
            logger.Verify(method => method.Log(It.IsAny<User>()), Times.Once, "We did not log once");
        }
    }
}
