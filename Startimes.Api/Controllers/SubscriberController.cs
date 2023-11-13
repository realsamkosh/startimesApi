using Microsoft.AspNetCore.Mvc;
using RPNL.Net.Utilities.ResponseUtil;
using Startimes.Service.Modules.StartTimes.Interface;

namespace Startimes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : BaseController
    {
        private readonly ISubscriberService _subscriberService;

        public SubscriberController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }

        [HttpGet("get-info/{serviceCode}")]
        public IActionResult GetSubscriber(string serviceCode)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateError();
            }

            var result = _subscriberService.QuerySubscribers(serviceCode);
            return Response(new ResponseModel
            {
                code = result.code,
                message = result.message,
                data = result.data,
                success = result.success,
            });
        }
        [HttpGet("recharge-info/{serviceCode}")]
        public IActionResult RechargeInfos(string serviceCode)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateError();
            }

            var result = _subscriberService.QuerySubscriberRechargeInfo(serviceCode);
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
