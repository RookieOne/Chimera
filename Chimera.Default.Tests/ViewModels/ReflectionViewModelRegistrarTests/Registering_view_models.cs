using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Chimera.Default.Routing.Extensions;
using Chimera.Default.UsedForReflectionTests.Foo;
using Chimera.Default.ViewModels;
using Chimera.Framework.Routing;
using Chimera.TestingUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chimera.Default.Tests.ViewModels.ReflectionViewModelRegistrarTests
{
    [TestClass]
    public class Registering_view_models
    {
        IDictionary<IRouteSignature, Type> _result;

        public void Setup()
        {
            var assembly = Assembly.GetAssembly(typeof(GetViewModel));
            _result = new ReflectionViewModelRegistrar().GetSignatures(assembly);
        }

        [TestMethod]
        public void should_register_view_model_with_registry()
        {
            Setup();

            _result.Keys.Count.ShouldBe(1);
        }

        [TestMethod]
        public void should_register_correct_route_signature()
        {
            Setup();

            var route = "get foo".ToRoute();

            _result.Keys.First().Matches(route).ShouldBeTrue();
        }

        [TestMethod]
        public void should_register_correct_view_model_type()
        {
            Setup();

            _result.Values.First().ShouldBe(typeof (GetViewModel));
        }
    }
}