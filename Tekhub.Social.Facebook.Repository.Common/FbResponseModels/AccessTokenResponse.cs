namespace Tekhub.Social.Facebook.Repository.Common.FbResponseModels
{
    public class AccessTokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(access_token);
        }
    }
}
