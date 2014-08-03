using Autofac;
using Autofac.Integration.Mvc;
using Software41.BackgroundCheck.Repository;
using Software41.BackgroundCheck.Web.Controllers;
using Software41.BackgroundCheck.Web.TestingFakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Software41.BackgroundCheck.Web
{
    public class ContainerConfiguration
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<FakeApplicantRepository>().As<IApplicantRepository>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            


        }

    }
}