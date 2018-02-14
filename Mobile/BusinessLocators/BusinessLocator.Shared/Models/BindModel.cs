using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLocator.Shared.Models
{
   public class TokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string userName { get; set; }
        public string roleName { get; set; }
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
}
