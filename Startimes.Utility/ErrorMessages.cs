namespace Startimes.Utility
{
    public static class ErrorMessages
    {
        public static string GetStartTimesErrorMessage(string code)
        {
            string message = string.Empty;
            switch (code)
            {
                case "package_not_found":
                    message = "Package not found";
                    break;
                case "more_than_one_package":
                    message = "More than one package found";
                    break;
                case "invalid_parameters":
                    message = "Interface parameters do not meet the requirements";
                    break;
                case "authorization_is_incorrect":
                    message = "The authorization in the header is incorrect";
                    break;
                case "invalid_mobile":
                    message = "The format of telephone is incorrect";
                    break;
                case "duplicate_serial_no":
                    message = "Transaction serial number is duplicate";
                    break;
                case "subscriber_status_not_applicable":
                    message = "Subscriber status not apply the current operation";
                    break;
                case "offer_no_not_available_for_customer":
                    message = "The customer can’t order the package";
                    break;
                case "offer_no_not_available_for_channel":
                    message = "Cannot order the package through the current channel";
                    break;
                case "current_time_customer_can_not_perform_the_operation":
                    message = "The customer cannot perform the operation at the current time";
                    break;
                case "mutex_with_ordered_offer":
                    message = "Mutex with ordered package";
                    break;
                case "dependant_offer_not_ordered":
                    message = "Did not order the dependent package";
                    break;
                case "balance_too_large":
                    message = "After recharge amount is too large";
                    break;
                case "partner_balance_not_enough":
                    message = "The payment merchant have not enough deposit";
                    break;
                case "overdue_the_change_times":
                    message = "Times for replacement package exceeds the maximum value for the month";
                    break;
                default:
                    break;
            }
            return message;
        }
    }
}