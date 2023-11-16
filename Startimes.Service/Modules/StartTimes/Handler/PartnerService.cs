using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using RPNL.Net.Utilities.ResponseUtil;
using Startimes.Data.DataObjects;
using Startimes.Data.DataObjects.Common;
using Startimes.Data.DataObjects.Partner;
using Startimes.Service.Modules.StartTimes.Interface;
using Startimes.Utility;

namespace Startimes.Service.Modules.StartTimes.Handler
{
    public class PartnerService : IPartnerService
    {
        private readonly GlobalConfig _settings;
        private readonly ILogger<PartnerService> _logger;

        public PartnerService(IOptions<GlobalConfig> settings, ILogger<PartnerService> logger)
        {
            _settings = settings.Value;
            _logger = logger;
        }

        public ResponseModel<PartnerBalanceViewModel> GetPartnersAccounts()
        {
            ResponseModel<PartnerBalanceViewModel> responseModel = new();
            try
            {
                var client = new RestClient($"{_settings.StartimeSettings.BaseUrl}/api-payment-service/v1/partners/accounts");
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
                    var result = JsonConvert.DeserializeObject<PartnerBalanceViewModel>(response?.Content);
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
        public ResponseModel<PartnerTransactionsViewModel> GetPartnersTransactions(string serialNo)
        {
            ResponseModel<PartnerTransactionsViewModel> responseModel = new();
            try
            {
                var client = new RestClient($"{_settings.StartimeSettings.BaseUrl}/api-payment-service/v1/partners/transactions/{serialNo}");
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
                    var result = JsonConvert.DeserializeObject<PartnerTransactionsViewModel>(response?.Content);
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
