using RPNL.Net.Utilities.ResponseUtil;
using Startimes.Data.DataObjects.Partner;

namespace Startimes.Service.Modules.StartTimes.Interface
{
    public interface IPartnerService
    {
        ResponseModel<PartnerBalanceViewModel> GetPartnersAccounts();
        ResponseModel<PartnerTransactionsViewModel> GetPartnersTransactions(string serialNo);
    }
}