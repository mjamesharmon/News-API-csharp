using System;
namespace NewsAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class RouteAttribute : Attribute
	{
		public string Route { get; }

		public RouteAttribute(string route)
		{
			Route = route;
		}
	}
}

