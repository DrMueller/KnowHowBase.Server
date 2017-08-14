using Mmu.Khb.Common.ApplicationSettings.Models;

namespace Mmu.Khb.Common.ApplicationSettings.Services
{
    public interface IAppSettingsProvider
    {
        AppSettings GetAppSettings();
    }
}