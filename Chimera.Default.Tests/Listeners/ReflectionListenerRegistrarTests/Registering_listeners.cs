using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Chimera.Default.Listeners;
using Chimera.Default.Routing.Extensions;
using Chimera.Default.UsedForReflectionTests.Foo;
using Chimera.Framework.Routing;
using Chimera.TestingUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chimera.Default.Tests.Listeners.ReflectionListenerRegistrarTests
{
    [TestClass]
    public class Registering_listeners
    {
        IDictionary<IRouteSignature, Type> _result;

        public void Setup()
        {
            var assembly = Assembly.GetAssembly(typeof (FooListener));
            
            _result = new ReflectionListenerRegistrar().GetSignatures(assembly);
        }

        [TestMethod]
        public void should_register_a_route()
        {
            Setup();

            _result.Keys.Count.ShouldBe(1);
        }

        [TestMethod]
        public void should_register_correct_route_signature()
        {
            Setup();

            var route = "save foo".ToRoute();

            _result.Keys.First().Matches(route).ShouldBeTrue();
        }

        [TestMethod]
        public void should_register_correct_listener_type()
        {
            Setup();

            _result.Values.First().ShouldBe(typeof (FooListener));
        }
    }
}