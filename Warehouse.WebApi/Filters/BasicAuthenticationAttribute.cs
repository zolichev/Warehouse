using System;
using System.Net.Http.Headers;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using Warehouse.Service;

namespace Warehouse.WebApi.Filters
{
	/// <inheritdoc cref="IAuthenticationFilter" />
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
	public class BasicAuthenticationAttribute : Attribute, IAuthenticationFilter
	{
		/// <inheritdoc />
		public bool AllowMultiple => false;

		/// <inheritdoc />
		public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
		{
			context.Principal = null;
			var authentication = context.Request.Headers.Authorization;
			if (authentication != null && authentication.Scheme == "Basic")
			{
				var authData = Encoding.ASCII.GetString(Convert.FromBase64String(authentication.Parameter)).Split(':');
				var roles = new[] {"client"};
				var login = authData[0];
				var password = authData[1];
				if (Dependency.ServiceLocator.ClientService.CheckAutentification(login, password))
					context.Principal = new GenericPrincipal(new GenericIdentity(login), roles);
			}

			if (context.Principal == null)
			{
				context.ErrorResult
					= new UnauthorizedResult(new[] {new AuthenticationHeaderValue("Basic")}, context.Request);
			}

			return Task.FromResult<object>(null);
		}

		/// <inheritdoc />
		public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
		{
			return Task.FromResult<object>(null);
		}
	}
}