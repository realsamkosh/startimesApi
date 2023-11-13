using RPNL.Net.Utilities.ResponseUtil;
using Startimes.Data.DataObjects.Startimes.Subscriber;

namespace Startimes.Service.Modules.StartTimes.Interface
{
    public interface ISubscriberService
    {
        ResponseModel<SubscriberViewModel> QuerySubscribers(string serviceCode);
        ResponseModel<SubscriberRechargeViewModel> QuerySubscriberRechargeInfo(string serviceCode);
    }
}