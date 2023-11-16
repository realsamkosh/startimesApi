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
                default:
                    break;
            }
            return message;
        }
    }
}