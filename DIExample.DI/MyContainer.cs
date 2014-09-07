using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using DIExample.Business;
using System.Configuration;

namespace DIExample.DI
{
    public class MyContainer : UnityContainer
    {
        private static IUnityContainer _container;

        public static IUnityContainer Container
        {
            get
            {
                if (_container != null)
                {
                    _container.Dispose();
                }
                _container = new UnityContainer();
                ConfigureContainer();
                return _container;
            }
        }

        private static void ConfigureContainer()
        {
            if (_container == null)
            {
                throw new InvalidOperationException("container is null");
            }
            _container.LoadConfiguration();
        }
    }
}
