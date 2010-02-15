using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Castle.Core;
using Castle.MicroKernel;
using Castle.Windsor;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;

namespace OrderProcessingDomain
{
  public static class IOC
  {

    const string NHDAC = "nhdac";
    const string OBJECT_DAC = "objectdac";
    const string DAC_MANAGER = "dacmanager";
    const string REPOSITORY_FACTORY = "repfactory";

    private static IWindsorContainer _container;

    public static void RegisterComponents()
    {
      if (_container == null)
      {
        _container = new WindsorContainer();
        _container.Register(
              Component.For<DACManager>().Named(DAC_MANAGER).LifeStyle.Singleton,
              Component.For<NHDataAccessContext>(),
              Component.For<IDataAccessContext>().ImplementedBy<NHDataAccessContext>().Named(NHDAC).LifeStyle.Singleton,
              Component.For<IDataAccessContext>().ImplementedBy<ObjectDataAccessContext>().Named(OBJECT_DAC).LifeStyle.Transient,
              Component.For(typeof(IRepository<>)).ImplementedBy(typeof(NHRepository<>)).ServiceOverrides(ServiceOverride.ForKey("dac").Eq(NHDAC)).LifeStyle.Transient.Named("nhrep1"),
              Component.For(typeof(IRepository<>)).ImplementedBy(typeof(NHRepository<>)).LifeStyle.Transient.Named("nhrep").LifeStyle.Transient,
              Component.For(typeof(IRepository<>)).ImplementedBy(typeof(ObjectRepository<>)).LifeStyle.Transient,
              Component.For(typeof(Repository<>)).Named(REPOSITORY_FACTORY).LifeStyle.Singleton
              );
      }
    }

    public static T Resolve<T>()
    {
      return _container.Resolve<T>();
    }

    public static T Resolve<T>(string key)
    {
      return _container.Resolve<T>(key);
    }
  }
}
