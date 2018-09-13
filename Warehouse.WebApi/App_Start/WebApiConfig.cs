using System.Web.Http;
using System.Web.Http.Cors;

namespace Warehouse.WebApi
{
	/// <summary>
	/// WebApiConfig
	/// </summary>
	public static class WebApiConfig
	{
		/// <summary>
		/// Register
		/// </summary>
		/// <param name="config">HttpConfiguration</param>
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services
			var cors = new EnableCorsAttribute("*", "*", "*");
			config.EnableCors(cors);

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
					name: "DefaultApi",
					routeTemplate: "api/store/{controller}/{id}",
					defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
