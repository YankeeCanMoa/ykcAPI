using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
public class ApiKeyMiddleware
{
	private readonly RequestDelegate _next;
	private readonly string _expectedApiKey;

	public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
	{
		_next = next;
		_expectedApiKey = configuration["AppSettings:ApiKey"];
	}

	public async Task Invoke(HttpContext context)
	{
		var apiKey = context.Request.Headers["ApiKey"].FirstOrDefault()?.Trim();

		if (IsAuthorizationRequired(context) && !IsValidApiKey(apiKey))
		{
			context.Response.StatusCode = 401; // Unauthorized
			await context.Response.WriteAsync("Invalid API key!!");
			return;
		}
		var claims = new[] { new System.Security.Claims.Claim("ApiKeyClaim", apiKey) };
		var identity = new System.Security.Claims.ClaimsIdentity(claims, "ApiKeyScheme");
		var principal = new System.Security.Claims.ClaimsPrincipal(identity);

		context.User = principal;
		await _next(context);
	}
	private bool IsAuthorizationRequired(HttpContext context)
	{
		// 현재 요청이 [Authorize] 속성이 있는지 확인
		var endpoint = context.GetEndpoint();
		return endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() == null;
	}

	private bool IsValidApiKey(string apiKey)
	{
		return apiKey == _expectedApiKey;
	}
}
