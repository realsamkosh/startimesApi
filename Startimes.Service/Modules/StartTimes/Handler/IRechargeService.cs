using RPNL.Net.Utilities.ResponseUtil;
using Startimes.Data.DataObjects.Startimes.Recharge;

namespace Startimes.Service.Modules.StartTimes.Handler
{
    public interface IRechargeService
    {
        ResponseModel<List<PackageRechargeInfoViewModel>> GetPackageRechargeInfo(string code);
        ResponseModel<RechargeViewModel> Recharge(RechargeDto model);
    }
}