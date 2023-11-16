using Microsoft.AspNetCore.Mvc;
using RPNL.Net.Utilities.ResponseUtil;
using Startimes.Data.DataObjects.Startimes.Recharge;
using Startimes.Service.Modules.StartTimes.Handler;

namespace Startimes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RechargeController : BaseController
    {
        private readonly IRechargeService _rechargeService;

        public RechargeController(IRechargeService rechargeService)
        {
            _rechargeService = rechargeService;
        }

        [HttpPost("recharge-package")]
        public IActionResult Recharge([FromBody] RechargeDto model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateError();
            }

            var result = _rechargeService.Recharge(model);
            return Response(new ResponseModel
            {
                code = result.code,
                message = result.message,
                data = result.data,
                success = result.success,
            });
        }

        [HttpGet("get-package-info/{code}")]
        public IActionResult PackageRechargeInfo(string code)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateError();
            }

            var result = _rechargeService.GetPackageRechargeInfo(code);
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
