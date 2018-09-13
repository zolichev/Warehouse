using System.Web.Http;
using Warehouse.Storage;

namespace Warehouse.WebApi
{
	/// <inheritdoc />
	public class WebApiApplication : System.Web.HttpApplication
	{
		/// <summary>
		/// Start application
		/// </summary>
		protected void Application_Start()
		{
			DbInitializer.Initialize();
			DependencyConfig.Register();
			GlobalConfiguration.Configure(WebApiConfig.Register);
		}
	}
}
