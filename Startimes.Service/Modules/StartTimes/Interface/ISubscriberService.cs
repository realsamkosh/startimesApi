using RPNL.Net.Utilities.ResponseUtil;
using Startimes.Data.DataObjects.Startimes.Subscriber;

namespace Startimes.Service.Modules.StartTimes.Interface
{
    public interface ISubscriberService
    {
        ResponseModel<SubscriberViewModel> QuerySubscribers(string serviceCode);
        ResponseModel<SubscriberRechargeViewModel> QueryRechargeInfo(string serviceCode);
        ResponseModel<SubscriberReplaceablePackageViewModel> QueryReplaceablePackage(string serviceCode);
    }
}