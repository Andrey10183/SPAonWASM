using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using TPA2.Shared;
using TPA2.Utility;

namespace TPA2.Pages
{
    public class LoginModel : ComponentBase
    {        
        [Inject] public ILocalStorageService LocalStorageService { get; set; }
        [Inject] public NavigationManager NavManager { get; set; }
        [Inject] public AuthenticationStateProvider AuthStateProvider { get; set; }
        public LoginModel()
        {
            LoginData = new LoginViewModel();
        }

        public LoginViewModel LoginData { get; set; }

        public string LoginStatus { get; set; }

        protected void ChangeInput()
        {
            LoginStatus = "";
        }

        protected async Task<bool> LoginAsync()
        {
            var user = Crypting.EncryptDecrypt(LoginData.UserName, Constants.EncryptKey);
            var record = await LocalStorageService.GetItemAsync<SecurityToken>(user);
                                   
            if (record != null)
                record = Crypting.EncryptDecryptToken(record);

            if (record != null && record.AccessToken == LoginData.Password)
            {                
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,record.UserName),
                    new Claim(ClaimTypes.Role,record.Role)
                };

                var identity = new ClaimsIdentity(claims, "Token");
                var principal = new ClaimsPrincipal(identity);
                var state = new AuthenticationState(principal);
                var tap = (TokenAuthenticationStateProvider)AuthStateProvider;
                tap.SetAuthenticationState(state);
                Console.WriteLine("SetAutorizState");
                NavManager.NavigateTo("/");
                return true;
            }

            LoginData.UserName = "";
            LoginData.Password = "";
            LoginStatus = "Wrong UserName or Password!";

            return false;
        }
    }
}
