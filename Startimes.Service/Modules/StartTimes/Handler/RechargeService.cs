using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using RPNL.Net.Utilities.ResponseUtil;
using Startimes.Data.DataObjects;
using Startimes.Data.DataObjects.Startimes.Subscriber;
using Startimes.Data.DataObjects.Startimes;
using Startimes.Data.DataObjects.Startimes.Recharge;
using Startimes.Utility;

namespace Startimes.Service.Modules.StartTimes.Handler
{
    public class RechargeService : IRechargeService
    {
        private readonly GlobalConfig _settings;
        private readonly ILogger<RechargeService> _logger;

        public RechargeService(IOptions<GlobalConfig> settings, ILogger<RechargeService> logger)
        {
            _settings = settings.Value;
            _logger = logger;
        }

        public ResponseModel<RechargeViewModel> Recharge(RechargeDto model)
        {
            ResponseModel<RechargeViewModel> responseModel = new();
            try
            {
                var client = new RestClient($"{_settings.StartimeSettings.BaseUrl}/api-payment-service/v1/recharging");
                var request = new RestRequest();
                // Add Basic Authentication header
                string credentials = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{_settings.StartimeSettings.Username}:{_settings.StartimeSettings.Password}"));
                request.AddHeader("Authorization", $"Basic {credentials}");
                request.AddHeader("co", $"{_settings.StartimeSettings.Co}");
                request.AddHeader("accept", "application/json");
                request.AddHeader("content-type", "application/json");
                request.AddJsonBody(model);
                RestResponse response = client.ExecutePostAsync(request).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<RechargeViewModel>(response?.Content);
                    responseModel.success = true;
                    responseModel.data = result;
                    responseModel.code = ErrorCodes.Successful;
                    return responseModel;
                }
                else
                {
                    var errorResult = JsonConvert.DeserializeObject<StartimeErrorViewModel>(response.Content);
                    responseModel.success = false;
                    responseModel.data = null;
                    responseModel.message = errorResult.ErrorCode;
                    responseModel.code = ErrorCodes.Failed;
                    return responseModel;
                }
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
        public ResponseModel<List<PackageRechargeInfoViewModel>> GetPackageRechargeInfo(string code)
        {
            ResponseModel<List<PackageRechargeInfoViewModel>> responseModel = new();
            try
            {
                var client = new RestClient($"{_settings.StartimeSettings.BaseUrl}//api-payment-service/v1/packages/{code}/recharge-infos");
                var request = new RestRequest();
                // Add Basic Authentication header
                string credentials = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{_settings.StartimeSettings.Username}:{_settings.StartimeSettings.Password}"));
                request.AddHeader("Authorization", $"Basic {credentials}");
                request.AddHeader("co", $"{_settings.StartimeSettings.Co}");
                request.AddHeader("accept", "application/json");
                request.AddHeader("content-type", "application/json");
                RestResponse response = client.ExecuteGetAsync(request).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<PackageRechargeInfoViewModel>>(response?.Content);
                    responseModel.success = true;
                    responseModel.data = result;
                    responseModel.code = ErrorCodes.Successful;
                    return responseModel;
                }
                else
                {
                    var errorResult = JsonConvert.DeserializeObject<StartimeErrorViewModel>(response.Content);
                    responseModel.success = false;
                    responseModel.data = null;
                    responseModel.message = ErrorMessages.GetStartTimesErrorMessage(errorResult.ErrorCode);
                    responseModel.code = ErrorCodes.Failed;
                    return responseModel;
                }
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
