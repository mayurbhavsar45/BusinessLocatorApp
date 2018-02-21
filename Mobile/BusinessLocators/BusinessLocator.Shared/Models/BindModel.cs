using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLocator.Shared.Models
{
    public class LoginModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string grant_type { get; set; }
    }

    public class UserRegistrationBindingModel
    {
        public int SiteId { get; set; }
        public string DisplayName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
        public string Password { get; set; }
        public double Longitude { get; set; }
        public double Lattitude { get; set; }

        public UserRegistrationBindingModel()
        {
            SiteId = 1;
        }

    }

    public class AccessTokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string userName { get; set; }
        public string roleName { get; set; }
    }

    public static class GlobalConfiguration
    {
        public static int SiteId = 1;
    }

    public class MapListView
    {
        public string UserID { get; set; }
        public string DisplayName { get; set; }
        public string Address1 { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
        public double Longitude { get; set; }
        public double Lattitude { get; set; }
    }
   
    public class UserProfileModel
    {
        public string UserID { get; set; }
        public int SiteID { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string eMailAddress { get; set; }
        public string WebSite { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string RoleId { get; set; }
        public double Longitude { get; set; }
        public double Lattitude { get; set; }

    }

}
