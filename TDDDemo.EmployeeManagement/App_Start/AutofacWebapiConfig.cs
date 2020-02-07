using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using TDDDemo.Employee.Business;
using TDDDemo.Employee.DataAccess;
using TDDDemo.Employee.Repository;

namespace TDDDemo.EmployeeManagement
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<EmployeeContext>()
               .As<EmployeeContext>()
               .InstancePerRequest();

            builder.RegisterType<UnitofWork>()
                   .As<IUnitofWork>()
                   .InstancePerRequest();

            builder.RegisterGeneric(typeof(Repository<>))
                  .As(typeof(IRepository<>))
                  .InstancePerRequest();

            builder.RegisterType<EmployeeRepository>()
                   .As<IEmployeeRepository>()
                   .InstancePerRequest();

            builder.RegisterType<ManageEmployee>()
                   .As<IManageEmployee>()
                   .InstancePerRequest();


            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }
    }
}