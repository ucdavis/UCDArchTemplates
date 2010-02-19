using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using UCDArch.Core.PersistanceSupport;

namespace UCDArchTemplates.Helpers
{
    public class FakeServiceLocator : ServiceLocatorImplBase
    {
        protected override object DoGetInstance(Type serviceType, string key)
        {
            if (serviceType == typeof(IDbContext))
            {
                return new FakeDBContext();
            }

            return null;
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}