﻿using Blazored.LocalStorage;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

#pragma warning disable CS8604 // Possible null reference argument.

namespace SocialApp.Client
{
    public class CustomStateAuthProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;

        public CustomStateAuthProvider(ILocalStorageService localStorage, HttpClient http)
        {
            _localStorage = localStorage;
            _http = http;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsStringAsync("authToken");

            var identity = new ClaimsIdentity();
            _http.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(token))
            {
                try {                     
                    var claims = ParseClaimsFromJwt(token);
                    identity = new ClaimsIdentity(claims, "jwt");
                    _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token.Replace("\"", ""));
                }
                catch (Exception)
                {
                    await _localStorage.RemoveItemAsync("authToken");
                    identity = new ClaimsIdentity();
                }
            }

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonConvert.
                DeserializeObject<Dictionary<string, object>>(Encoding.UTF8.GetString(jsonBytes));
            
            var claims = keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
            return claims;
        }
    }
}
