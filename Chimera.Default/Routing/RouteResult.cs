using System;
using System.Collections.Generic;
using Chimera.Framework.Extensions;
using Chimera.Framework.Routing;
using Chimera.Framework.Routing.Extensions;

namespace Chimera.Default.Routing
{
    public class RouteResult : IRouteResult
    {
        public RouteResult()
        {
            _history = new List<IRoute>();
        }

        public RouteResult(IRoute route)
            : this()
        {
            var result = route as IRouteResult;

            if (result != null)
            {
                CopyFrom(result);
            }
            else
            {
                Success = true;                
            }

            AddHistory(route);
        }

        readonly List<IRoute> _history;
        public IRoute NextRoute { get; private set; }
        public bool Success { get; private set; }
        public string Message { get; private set; }

        public IEnumerable<IRoute> History
        {
            get { return _history; }
        }

        public IRouteResult Next(IRoute route)
        {
            NextRoute = route;
            return this;
        }

        public string Action
        {
            get { return NextRoute.Action; }
        }

        public string Resource
        {
            get { return NextRoute.Resource; }
        }

        public Dictionary<string, object> Parameters
        {
            get { return NextRoute.Parameters; }
        }

        public object this[string s]
        {
            get { return NextRoute.Parameters[s]; }
        }

        public long Start { get; set; }
        public long End { get; set; }

        public void CopyFrom(IRouteResult result)
        {
            Success = result.Success;
            Message = result.Message;

            result.History.ForEach(_history.Add);
        }

        public static IRouteResult NoMappedFunc(IRoute route)
        {
            var result = new RouteResult
                             {
                                 Success = false,
                                 Message = "No function mapped for route {0}".FormatWith(route)
                             };
            result.AddHistory(route);

            return result;
        }

        public void AddHistory(IRoute route)
        {
            _history.Add(route);
        }

        public override bool Equals(object obj)
        {
            var route = obj as IRoute;

            if (route != null)
                return this.RouteEquals(route);

            return base.Equals(obj);
        }

        public override string ToString()
        {
            return this.AsString();
        }

        public void AddParameter(string key, object value)
        {
            if (NextRoute != null)
            {
                NextRoute.Parameters.Add(key, value);
            }
        }
    }
}