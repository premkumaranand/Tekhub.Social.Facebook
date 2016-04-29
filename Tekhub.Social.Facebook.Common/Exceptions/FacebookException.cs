using System;

namespace Tekhub.Social.Facebook.Common.Exceptions
{
    public class FacebookException : ApplicationException
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public FacebookException(int theErrorCode, string theErrorMessage)
        {
            ErrorCode = theErrorCode;
            ErrorMessage = theErrorMessage;
        }

        public override string ToString()
        {
            return ErrorMessage;
        }
    }
}
