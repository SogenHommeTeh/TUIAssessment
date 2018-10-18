using System.Linq;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc.Filters;
using TUI.Error.Exceptions;
using Newtonsoft.Json;

namespace TUI.Error.Filters
{
    public class ValidationModelFilter : IActionFilter
    {
        private readonly TelemetryClient _telemetryClient;

        public ValidationModelFilter(TelemetryClient telemetryClient)
        {
            _telemetryClient = telemetryClient;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid) return;
            if (context.ModelState.Keys.Any())
            {
                _telemetryClient.TrackTrace(JsonConvert.SerializeObject(context.ModelState.Select(x => new { x.Key, x.Value.RawValue, x.Value.Errors })));
            }
            throw new InvalidParameterException();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}