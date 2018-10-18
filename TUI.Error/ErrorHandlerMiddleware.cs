using System;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TUI.Error.Exceptions;
using TUI.Error.Responses;

namespace TUI.Error
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;
        private readonly TelemetryClient _telemetryClient;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger, TelemetryClient telemetryClient)
        {
            _next = next;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _telemetryClient = telemetryClient;
        }

        public async Task Invoke(HttpContext context)
        {
            ApiResponse response;

            try
            {
                await _next.Invoke(context);
                response = new ApiResponse(context.Response.StatusCode);
            }
            catch (ApiException e)
            {
                _telemetryClient.TrackException(e);
                response = new ApiResponseWithException(e);
            }
            catch (Exception e)
            {
                _telemetryClient.TrackException(e);
                response = new ApiResponse(500);
            }

            await ApiResponseAsync(context, response);
        }

        private static async Task ApiResponseAsync(HttpContext context, ApiResponse response)
        {
            if (!context.Response.HasStarted)
            {
                context.Response.StatusCode = response.StatusCode;
                context.Response.ContentType = "application/json";

                var contractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                };

                var json = JsonConvert.SerializeObject(response, new JsonSerializerSettings
                {
                    ContractResolver = contractResolver
                });

                await context.Response.WriteAsync(json);
            }
        }
    }
}
