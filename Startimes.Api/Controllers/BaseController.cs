using Microsoft.AspNetCore.Mvc;
using RPNL.Net.Utilities.ResponseUtil;

namespace Startimes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult NotifyModelStateError()
        {
            var erroMesg = new List<string>();
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var msg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                erroMesg.Add(msg);
            }
            ResponseModel response = new()
            {
                code = ErrorCodes.Failed,
                message = erroMesg.FirstOrDefault(),
                success = false
            };
            return BadRequest(response);
        }

        protected new IActionResult Response(ResponseModel result = null, bool useOnlyOkStatus = true)
        {
            if (useOnlyOkStatus == true)
            {
                return Ok(result);
            }
            else
            {
                if (result.code == ErrorCodes.Successful)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
        }
    }
}
