using System;
namespace NewsAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Class,
		AllowMultiple = false, Inherited = false)]
    internal class RouteAttribute : Attribute
	{
		public string Route { get; }

		public RouteAttribute(string route)
		{
			Route = route;
		}
	}
}

