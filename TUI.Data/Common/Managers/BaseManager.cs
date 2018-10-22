using Microsoft.ApplicationInsights;

namespace TUI.Data.Common.Managers
{
    public class BaseManager
    {
        protected readonly TelemetryClient TelemetryClient;

        public BaseManager(TelemetryClient telemetryClient)
        {
            TelemetryClient = telemetryClient;
        }
    }
}
