using PMSAPP.Entities;
using PMSAPP.UserInterface.Models;
using PMSAPP.BusinessLogicLayer.Implementation;
using PMSAPP.BusinessLogicLayer.Abstract;
using PMSAPP.BusinessLogicLayer.IOC;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
using Unity.Mvc5;

namespace PMSAPP.UserInterface
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            //container.RegisterType<
            //    IDataFetcher<Product>, DataFetcher>(
            //    new ContainerControlledLifetimeManager());
            container.RegisterType<
                IDataFetcher<Product>, DataFetcher>();

            container.RegisterType<
                IBusinessComponent<Product>, ProductBusinessComponent>();

            container.
                AddNewExtension<DependencyExtension>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}