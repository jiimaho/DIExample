using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIExample.Business
{
    public class UserHandler : IUserHandler
    {
        private readonly IUserLogger _logger;

        public UserHandler(IUserLogger logger)
        {
            _logger = logger;
        }

        public void Save(User user)
        {
            if (user.UserName == "")
            {
                throw new InvalidUser();
            }

            _logger.Log(user);
        }
    }
}
