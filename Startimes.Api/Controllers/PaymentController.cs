using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPNL.Net.Utilities.ResponseUtil;
using Startimes.Service.Modules.StartTimes.Interface;

namespace Startimes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : BaseController
    {
        private readonly IStartimesPaymentApiService _paymentApiService;

        public PaymentController(IStartimesPaymentApiService  paymentApiService)
        {
            _paymentApiService = paymentApiService;
        }


        [HttpGet("service-status")]
        public IActionResult ServiceStatus()
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateError();
            }

            var result = _paymentApiService.ServiceStatus();
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
