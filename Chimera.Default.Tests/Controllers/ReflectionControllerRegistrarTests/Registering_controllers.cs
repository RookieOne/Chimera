using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Chimera.Default.Controllers;
using Chimera.Default.Routing.Extensions;
using Chimera.Default.UsedForReflectionTests.Foo;
using Chimera.Framework.Routing;
using Chimera.TestingUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chimera.Default.Tests.Controllers.ReflectionControllerRegistrarTests
{
    [TestClass]
    public class Registering_controllers
    {
        IDictionary<IRouteSignature, Type> _result;

        public void Setup()
        {
            var assembly = Assembly.GetAssembly(typeof(TestController)); ;
            _result = new ReflectionControllerRegistrar().GetSignatures(assembly);
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

            var route = "someaction foo".ToRoute();

            _result.Keys.First().Matches(route).ShouldBeTrue();
        }

        [TestMethod]
        public void should_register_correct_controller_type()
        {
            Setup();

            _result.Values.First().ShouldBe(typeof (TestController));
        }
    }
}