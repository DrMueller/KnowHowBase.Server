using System.Collections.Generic;

namespace Mmu.Khb.Common.ServiceProvisioning
{
    public interface IProvisioningService
    {
        IReadOnlyCollection<T> GetAllServices<T>();

        T GetService<T>();
    }
}