using Autofac;
using Autofac.Integration.Mvc;
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

namespace Software41.BackgroundCheck.Web
{
    public class ContainerConfiguration
    {
        public static void Configure()
        {
            //would like to scan for components to load.
            //most likely will have to add the list of components to the config file vs. dynamically loading all .dlls found in the 
            //bin directory
            //http://autofac.readthedocs.org/en/latest/register/scanning.html#scanning-for-modules

            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());


            builder.RegisterType<BackgroundCheckContext>().As<IUnitOfWork>().InstancePerHttpRequest();
            builder.RegisterType<EFApplicantRepository>().As<IApplicantRepository>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            


        }

    }
}