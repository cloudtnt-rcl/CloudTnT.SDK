#nullable disable

using System.Security.Claims;

namespace CloudTnT.SDK
{
    public static class UserClaimsHelper
    {
        public static UserClaimsData GetUserDataFromClaims(ClaimsPrincipal User)
        {
            UserClaimsData userClaimsData = new UserClaimsData();

            string objectId = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value ?? string.Empty;
            if (!string.IsNullOrEmpty(objectId))
            {
                userClaimsData.ObjectId = objectId;
                userClaimsData.UUID = ShortenObjectId(objectId);
            }

            string displayName = User.Claims.FirstOrDefault(c => c.Type == "name")?.Value ?? string.Empty;
            if (!string.IsNullOrEmpty(displayName))
            {
                userClaimsData.DisplayName = displayName;
            }

            string email = User.Claims.FirstOrDefault(c => c.Type == "emails")?.Value ?? string.Empty;
            if (!string.IsNullOrEmpty(email))
            {
                userClaimsData.Email = email;
            }

            string idToken = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.UserData)?.Value ?? string.Empty;
            if (!string.IsNullOrEmpty(idToken))
            {
                userClaimsData.IdToken = idToken;
            }

            return userClaimsData;
        }

        public static string ShortenObjectId(string objectId)
        {
            return objectId.Replace("-", "").TrimStart('0');
        }
    }
}
