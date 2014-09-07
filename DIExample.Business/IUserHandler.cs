using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIExample.Business
{
    public interface IUserHandler
    {
        void Save(User user);
    }
}
