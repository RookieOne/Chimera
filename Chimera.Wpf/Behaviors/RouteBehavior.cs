using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Chimera.Default.Routing;
using Chimera.Framework.Routing.Extensions;
using Chimera.Framework.Utilities;
using Chimera.Wpf.AttachedProperties;
using Chimera.Wpf.Commands;

namespace Chimera.Wpf.Behaviors
{
    public static class RouteBehavior
    {
        static RouteBehavior()
        {
            RouteProperty = DependencyProperty.RegisterAttached("Route",
                                                                typeof (string),
                                                                typeof (RouteBehavior),
                                                                new PropertyMetadata(OnRouteChanged));

            ParamsProperty = DependencyProperty.RegisterAttached("Params",
                                                                 typeof (List<RouteParameter>),
                                                                 typeof (RouteBehavior),
                                                                 new PropertyMetadata());
        }

        public static readonly DependencyProperty ParamsProperty;
        public static readonly DependencyProperty RouteProperty;

        public static string GetRoute(DependencyObject o)
        {
            return (string) o.GetValue(RouteProperty);
        }

        public static void SetRoute(DependencyObject o, string value)
        {
            o.SetValue(RouteProperty, value);
        }

        public static List<RouteParameter> GetParams(DependencyObject o)
        {
            return (List<RouteParameter>) o.GetValue(ParamsProperty);
        }

        public static void SetParams(DependencyObject o, List<RouteParameter> value)
        {
            o.SetValue(ParamsProperty, value);
        }

        static void EnsureParamList(DependencyObject o)
        {
            var list = (List<RouteParameter>) o.GetValue(ParamsProperty);

            if (list == null)
            {
                list = new List<RouteParameter>();
                SetParams(o, list);
            }
        }

        static void OnRouteChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            EnsureParamList(d);

            var button = d as Button;

            if (button == null)
                return;

            Action routeAction = () =>
                                     {
                                         var route = CreateRoute(d);
                                         route.Send();
                                     };
            button.Command = new DelegateCommand(routeAction);
        }

        static Route CreateRoute(DependencyObject d)
        {
            var routeString = GetRoute(d);

            var action = routeString.Split(' ')[0];
            var resource = routeString.Split(' ')[1];

            var route = new Route(action, resource);

            var view = ViewProperties.GetView(d);
            route.AddParameter(KnownParameters.ParentView, view);
            var showAs = ViewProperties.GetShowAs(d);
            route.AddParameter(KnownParameters.ParentShowAs, showAs);

            var parameters = GetParams(d);

            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    var element = d as FrameworkElement;
                    p.DataContext = element.DataContext;
                    route.AddParameter(p.Key, p.Value);
                }
            }

            return route;
        }
    }
}