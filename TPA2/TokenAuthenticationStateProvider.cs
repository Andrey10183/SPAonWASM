using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IO.Pipes;
using System.Security.Claims;
using TPA2.Pages;

namespace TPA2
{
    public class TokenAuthenticationStateProvider : AuthenticationStateProvider
    {
        private AuthenticationState _authState;

        public TokenAuthenticationStateProvider()
        {
            _authState = ReturnAnonymous();
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //server communication immitation
            await Task.Delay(500);

            return _authState;
        }

        public void SetAuthenticationState(AuthenticationState authState)
        {
            _authState = authState ?? ReturnAnonymous();
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public AuthenticationState ReturnAnonymous()
        {
            var anonymousIdentity = new ClaimsIdentity();
            var anonimousePrincipal = new ClaimsPrincipal(anonymousIdentity);
            return new AuthenticationState(anonimousePrincipal);
        }
    }
}
