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
			Dependency.Config();
			GlobalConfiguration.Configure(WebApiConfig.Register);
		}
	}
}
