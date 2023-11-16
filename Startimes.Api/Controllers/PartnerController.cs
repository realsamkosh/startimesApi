using Microsoft.AspNetCore.Mvc;
using RPNL.Net.Utilities.ResponseUtil;
using Startimes.Data.DataObjects.Recharge;
using Startimes.Service.Modules.StartTimes.Handler;
using Startimes.Service.Modules.StartTimes.Interface;

namespace Startimes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : BaseController
    {
        private readonly IPartnerService _partnerService;

        public PartnerController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        [HttpGet("get-transactions/{serialNo}")]
        public IActionResult GetTransactions(string serialNo)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateError();
            }

            var result = _partnerService.GetPartnersTransactions(serialNo);
            return Response(new ResponseModel
            {
                code = result.code,
                message = result.message,
                data = result.data,
                success = result.success,
            });
        }

        [HttpGet("get-accounts")]
        public IActionResult GetAccounts()
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateError();
            }

            var result = _partnerService.GetPartnersAccounts();
            return Response(new ResponseModel
            {
                code = result.code,
                message = result.message,
                data = result.data,
                success = result.success,
            });
        }
    }
}
