using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using RPNL.Net.Utilities.ResponseUtil;
using Startimes.Data.DataObjects;
using Startimes.Data.DataObjects.Common;
using Startimes.Data.DataObjects.Subscriber;
using Startimes.Service.Modules.StartTimes.Interface;

namespace Startimes.Service.Modules.StartTimes.Handler
{
    public class SubscriberService : ISubscriberService
    {
        private readonly GlobalConfig _settings;
        private readonly ILogger<SubscriberService> _logger;

        public SubscriberService(IOptions<GlobalConfig> settings, ILogger<SubscriberService> logger)
        {
            _settings = settings.Value;
            _logger = logger;
        }
        public ResponseModel<SubscriberViewModel> QuerySubscribers(string serviceCode)
        {
            ResponseModel<SubscriberViewModel> responseModel = new();
            try
            {
                var client = new RestClient($"{_settings.StartimeSettings.BaseUrl}/api-payment-service/v1/subscribers/{serviceCode}");
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
                    var result = JsonConvert.DeserializeObject<SubscriberViewModel>(response?.Content);
                    responseModel.success = true;
                    responseModel.data = result;
                    responseModel.code = ErrorCodes.Successful;
                    return responseModel;
                }
                else
                {
                    var errorResult1 = JsonConvert.DeserializeObject<StartimeErrorViewModel>(response.Content);
                    responseModel.success = false;
                    responseModel.message = errorResult1.ErrorCode;
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
        public ResponseModel<SubscriberRechargeViewModel> QueryRechargeInfo(string serviceCode)
        {
            ResponseModel<SubscriberRechargeViewModel> responseModel = new();
            try
            {
                var client = new RestClient($"{_settings.StartimeSettings.BaseUrl}/api-payment-service/v1/subscribers/{serviceCode}/recharge-infos");
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
                    var result = JsonConvert.DeserializeObject<SubscriberRechargeViewModel>(response?.Content);
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
        public ResponseModel<SubscriberReplaceablePackageViewModel> QueryReplaceablePackage(string serviceCode)
        {
            ResponseModel<SubscriberReplaceablePackageViewModel> responseModel = new();
            try
            {
                var client = new RestClient($"{_settings.StartimeSettings.BaseUrl}/api-payment-service/v1/subscribers/{serviceCode}/replaceable-packages");
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
                    var result = JsonConvert.DeserializeObject<SubscriberReplaceablePackageViewModel>(response?.Content);
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
    }
}
