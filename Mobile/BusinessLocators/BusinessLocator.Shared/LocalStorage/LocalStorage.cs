using System;
using System.Diagnostics;
using BusinessLocator.Shared.Models;
using BusinessLocator.Shared.Service;
using Plugin.Settings;


namespace BusinessLocator.Shared
{
    public class LocalStorage
    {
        public LocalStorage() { }
       
        public static void SaveLogin(TokenResponse Result)
        {
            CrossSettings.Current.AddOrUpdateValue("AccessToken", Result.access_token);
            CrossSettings.Current.AddOrUpdateValue("TokenType", Result.token_type);
            CrossSettings.Current.AddOrUpdateValue("ExpiresIn", Result.expires_in);
            CrossSettings.Current.AddOrUpdateValue("UserName", Result.userName);
            CrossSettings.Current.AddOrUpdateValue("RoleName", Result.roleName);
        }
        
    }
}
    

