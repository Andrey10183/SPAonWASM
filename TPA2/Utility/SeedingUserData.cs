using Blazored.LocalStorage;
using TPA2.Pages;
using TPA2.Shared;

namespace TPA2.Utility
{
    public class SeedingUserData
    {
        private List<SecurityToken> dictSeed = new List<SecurityToken>()
        {
            new SecurityToken(){ UserName="admin", AccessToken = "123456", Role = "administrator" },
            new SecurityToken(){ UserName="Richard", AccessToken = "Seagull", Role = "user" },
            new SecurityToken(){ UserName="Andy", AccessToken = "Super", Role = "user" },
            new SecurityToken(){ UserName="Solomon", AccessToken = "CruelDominator", Role = "administrator" },
            new SecurityToken(){ UserName="April", AccessToken = "BeautyArchid", Role = "user" }
        };

        private readonly ILocalStorageService _localStorage;

        public SeedingUserData(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            SeedData();
        }

        public async Task SeedData()
        {
            await _localStorage.ClearAsync();
            foreach (var item in dictSeed)
            {
                var cryptedKey = Crypting.EncryptDecrypt(item.UserName, Constants.EncryptKey);
                var cryptedValue = Crypting.EncryptDecryptToken(item);
                await _localStorage.SetItemAsync(cryptedKey, cryptedValue);
            }
        }
    }
}
