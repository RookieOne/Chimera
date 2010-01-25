using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Chimera.Framework.IoC.StructureMap;
using Chimera.Framework.Locators;
using Chimera.Framework.Locators.Conventions;
using Chimera.Framework.Routing.Default.Tests.TestingHelpers;
using Chimera.Framework.Routing.FluentConfig;

namespace Chimera.Framework.Routing.Default.Tests.FluentConfigTests.RepositoryTests
{
    public class RepositoryTests
    {
        void SetupRepositories()
        {
            var locator = new StructureMapLocator();

            new LocatorConfig(locator)
                .SetupDefaultConventions()                
                .ConfigureWithConventionsFromAssembly(Assembly.GetAssembly(typeof(RoutingEngine)))
                .ConfigureWithConventionsFromAssembly(Assembly.GetAssembly(this.GetType()));

            Locator.SetImplementation(locator);

            RegisterRoutes
                .For("Save")
                .If(r => r.HasSingleParameterOfType<IEntity>())
                .Then(r => SaveUsingRepository);
                .FromAssembly(Assembly.GetAssembly(this.GetType()))
                .FromTypes(t => t.Name.EndsWith("Controller"))
                .UnderResourceName(t => t.Name.Replace("Controller", ""))
                .AllPublicMethods();
        }

        public void should_call_save_on_repository()
        {
            
        }
    }

    public interface IEntity{}

    public interface IRepository<T>
    {
        void Save<T>(T entity);
    }

    public class Order : IEntity
    {        
    }
    
    public class Repository<T> : IRepository<T>
    {       
        public void Save<T>(T entity)
        {
            MockLog.Record("SaveCalled", true);
            MockLog.Record("EntitSaved", entity);
        }
    }
}
