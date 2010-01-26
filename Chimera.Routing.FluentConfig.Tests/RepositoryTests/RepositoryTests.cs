using System.Linq;
using System.Reflection;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.Routing;
using Chimera.Routing.Default;
using Chimera.StructureMap;
using Chimera.TestingUtilities;
using Xunit;

namespace Chimera.Routing.FluentConfig.Tests.RepositoryTests
{
    public class RepositoryTests
    {
        void SetupRepositories()
        {
            var container = new StructureMapContainer();
            container.Container.Configure(x => x.ForRequestedType(typeof (IRepository<>))
                                                   .TheDefaultIsConcreteType(typeof (Repository<>)));


            new IocConfig(container)
                .SetupDefaultConventions()
                .ConfigureWithConventionsFromAssembly(Assembly.GetAssembly(typeof (RoutingEngine)))
                .ConfigureWithConventionsFromAssembly(Assembly.GetAssembly(this.GetType()));

            IoC.SetImplementation(container);

            RegisterRoutes
                .For("Save")
                .If(r => r.HasSingleParameterOfType<IEntity>())
                .Then(SaveUsingRepository);
        }

        void SaveUsingRepository(IRoute route)
        {
            var a = Assembly.GetAssembly(this.GetType());
            var resourceType = a.GetTypes().FirstOrDefault(t => t.Name == route.Resource);

            var methodToInvoke = GetType().GetMethods().FirstOrDefault(m => m.Name.Contains("SaveUsingGenericRepository"));

            methodToInvoke
                .MakeGenericMethod(resourceType)
                .Invoke(this, new[] {route});
        }

        public void SaveUsingGenericRepository<T>(IRoute route)
        {
            var entity = (T) route.Parameters.First().Value;
            var repository = IoC.Get<IRepository<T>>();
            
            repository.Save(entity);
        }

        [Fact]
        public void should_have_one_route_signature()
        {
            SetupRepositories();

            IoC.Get<IRoutingEngine>().GetRouteSignatures().Count().ShouldBe(1);
        }

        [Fact]
        public void should_call_save_on_repository()
        {
            SetupRepositories();

            var order = new Order();
            var route = new Route("Save", "Order").AddParameter("Order", order);

            IoC.Get<IRoutingEngine>().Resolve(route).Invoke(route);

            MockLog.Read<bool>("SaveCalled").ShouldBeTrue();
            MockLog.Read<Order>("EntitySaved").ShouldBeTheSameAs(order);
        }
    }

    public interface IEntity
    {
    }

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