using System.Text.Json;
using System.Text.Json.Serialization;

namespace Avanade.IT.ChallengeSE.Api.Configurations
{
    public static class ControllersSetup
    {
        public static void AddControllersSetup(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddJsonOptions(d =>
                {
                    d.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                    d.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    d.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    d.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    d.JsonSerializerOptions.WriteIndented = true;
                    d.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                });
        }
    }
}
