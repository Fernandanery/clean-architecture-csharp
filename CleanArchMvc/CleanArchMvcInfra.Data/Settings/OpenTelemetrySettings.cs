using CleanArchMvc.Infra.Data.Interfaces;

namespace CleanArchMvc.Infra.Data.Settings
{
    public class OpenTelemetrySettings : IAppSettings
    {
        public string Endpoint { get; init; }
        public string Application { get; init; }
        public string Header { get; init; }
    }
}
