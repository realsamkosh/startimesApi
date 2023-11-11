using RPNL.Net.Utilities.ResponseUtil;
using Startimes.Data.DataObjects.Startimes;

namespace Startimes.Service.Modules.StartTimes.Interface
{
    public interface IStartimesApiService
    {
        ResponseModel<ServiceStatusViewModel> ServiceStatus();
    }
}