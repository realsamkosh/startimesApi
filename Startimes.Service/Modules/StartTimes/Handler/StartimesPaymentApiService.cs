using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using RPNL.Net.Utilities.ResponseUtil;
using Startimes.Data.DataObjects;
using Startimes.Data.DataObjects.Startimes;
using Startimes.Service.Modules.StartTimes.Interface;
using System.Runtime;

namespace Startimes.Service.Modules.StartTimes.Handler
{
    public class StartimesPaymentApiService : IStartimesPaymentApiService
    {
        private readonly GlobalConfig _settings;
        private readonly ILogger<StartimesPaymentApiService> _logger;

        public StartimesPaymentApiService(IOptions<GlobalConfig> settings, ILogger<StartimesPaymentApiService> logger)
        {
            _settings = settings.Value;
            _logger = logger;
        }

        public ResponseModel<ServiceStatusViewModel> ServiceStatus()
        {
            ResponseModel<ServiceStatusViewModel> responseModel = new();
            try
            {
                var client = new RestClient($"http://{_settings.StartimeSettings.IPAddress}:{_settings.StartimeSettings.Port}/api-payment-service/v1/service-status");
                var request = new RestRequest();
                request.AddHeader("co", $"{_settings.StartimeSettings.Co}");
                request.AddHeader("accept", "application/json");
                request.AddHeader("content-type", "application/json");
                RestResponse response = client.ExecutePostAsync(request).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<ServiceStatusViewModel>(response?.Content);
                    responseModel.success = true;
                    responseModel.data = result;
                    responseModel.code = ErrorCodes.Successful;
                    return responseModel;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var errorResult = JsonConvert.DeserializeObject<ServiceStatusViewModel>(response.Content);
                    responseModel.success = false;
                    responseModel.data = errorResult;
                    responseModel.code = ErrorCodes.Failed;
                    return responseModel;
                }

                responseModel.success = false;
                responseModel.data = null;
                responseModel.message = "Validation FAILED";
                responseModel.code = ErrorCodes.Failed;
                return responseModel;
            }
            catch (Exception ex)
            {
                _logger.LogError("Verification Failed", ex);
                responseModel.success = false;
                responseModel.data = null;
                responseModel.message = ex.Message;
                responseModel.code = ErrorCodes.Failed;
                return responseModel;
            }
        }
    }
}
