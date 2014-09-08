using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Software41.BackgroundCheck.Repository;
using Software41.BackgroundCheck.Repository.EF;
using Software41.BackgroundCheck.Web.Controllers;
using Software41.BackgroundCheck.Web.TestingFakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;


namespace Software41.BackgroundCheck.Web
{
    public class ContainerConfiguration
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            builder.RegisterType<BackgroundCheckContext>().As<IUnitOfWork>().InstancePerHttpRequest();
            builder.RegisterType<EFApplicantRepository>().As<IApplicantRepository>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);


        }

    }
}