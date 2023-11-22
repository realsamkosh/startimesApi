using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using RPNL.Net.Utilities.ResponseUtil;
using Startimes.Data.DataObjects;
using Startimes.Data.DataObjects.Common;
using Startimes.Data.DataObjects.Partner;
using Startimes.Data.DataObjects.VIP;
using Startimes.Utility;

namespace Startimes.Service.Modules.StartTimes.Handler
{
    public class VIPService
    {
        private readonly GlobalConfig _settings;
        private readonly ILogger<VIPService> _logger;

        public VIPService(IOptions<GlobalConfig> settings, ILogger<VIPService> logger)
        {
            _settings = settings.Value;
            _logger = logger;
        }

        public ResponseModel<AuthResponseModel> OAuthToken()
        {
            ResponseModel<AuthResponseModel> responseModel = new();
            try
            {
                var client = new RestClient($"{_settings.BusinessSettings.BaseUrl}/ec-order/platform/v1/oauth/token");
                var request = new RestRequest();
                // Add Basic Authentication header
                string credentials = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{_settings.BusinessSettings.Username}:{_settings.BusinessSettings.Password}"));
                request.AddHeader("Authorization", $"Basic {credentials}");
                request.AddHeader("grant", "client_credentials");
                request.AddHeader("accept", "application/json");
                request.AddHeader("content-type", "application/json");
                RestResponse response = client.ExecutePostAsync(request).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<AuthResponseModel>(response?.Content);
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
        public ResponseModel<VIPActivationViewModel> Activate(VIPActivationDto model)
        {
            ResponseModel<VIPActivationViewModel> responseModel = new();
            try
            {
                var client = new RestClient($"{_settings.BusinessSettings.BaseUrl}/ec-order/platform/vip/v1/activate");
                var request = new RestRequest();
                // Add Basic Authentication header
                var credentials = OAuthToken();
                request.AddHeader("Authorization", $"Bearer {credentials.data.AccessToken}");
                request.AddHeader("accept", "application/json");
                //request.AddHeader("msisdn", model.Msisdn);
                //request.AddHeader("subscriptionId", model.SubscriptionId);
                //request.AddHeader("nonceStr", model.NonceStr);
                //request.AddHeader("sign", model.Sign);
                //request.AddHeader("requestTime", model.RequestTime);
                //request.AddHeader("reference", model.Reference);
                request.AddHeader("CountryCode", "NG");
                request.AddHeader("content-type", "application/json");
                request.AddJsonBody(model);
                RestResponse response = client.ExecutePostAsync(request).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<VIPActivationViewModel>(response?.Content);
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
        public ResponseModel<VIPUserStatus> UserStatus(VIPActivationDto model)
        {
            ResponseModel<VIPUserStatus> responseModel = new();
            try
            {
                var client = new RestClient($"{_settings.BusinessSettings.BaseUrl}/ec-order/platform/vip/v1/user/status");
                var request = new RestRequest();
                // Add Basic Authentication header
                var credentials = OAuthToken();
                request.AddHeader("Authorization", $"Bearer {credentials.data.AccessToken}");
                request.AddHeader("CountryCode", "NG");
                request.AddHeader("accept", "application/json");
                request.AddHeader("content-type", "application/json");
                request.AddJsonBody(model);
                RestResponse response = client.ExecutePostAsync(request).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<VIPUserStatus>(response?.Content);
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
