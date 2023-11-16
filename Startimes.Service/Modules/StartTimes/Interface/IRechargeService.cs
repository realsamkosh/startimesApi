using RPNL.Net.Utilities.ResponseUtil;
using Startimes.Data.DataObjects.Recharge;

namespace Startimes.Service.Modules.StartTimes.Interface
{
    public interface IRechargeService
    {
        ResponseModel<List<PackageRechargeInfoViewModel>> GetPackageRechargeInfo(string code);
        ResponseModel<RechargeViewModel> Recharge(RechargeDto model);
    }
}