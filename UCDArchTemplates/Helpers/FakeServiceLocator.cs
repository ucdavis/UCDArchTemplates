using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using UCDArch.Core.PersistanceSupport;
using UCDArch.Core.CommonValidator;

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

            if (serviceType == typeof(IValidator))
            {
                return new FakeValidator();
            }

            return null;
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}