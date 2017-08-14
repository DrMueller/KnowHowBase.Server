using Microsoft.Extensions.Options;
using Mmu.Khb.Common.ApplicationSettings.Models;

namespace Mmu.Khb.Common.ApplicationSettings.Services.Implementation
{
    public class AppSettingsProvider : IAppSettingsProvider
    {
        private readonly IOptions<AppSettings> _appSettingsOptions;

        public AppSettingsProvider(IOptions<AppSettings> appSettingsOptions)
        {
            _appSettingsOptions = appSettingsOptions;
        }

        public AppSettings GetAppSettings()
        {
            return _appSettingsOptions.Value;
        }
    }
}