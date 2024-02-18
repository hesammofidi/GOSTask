using Blazored.LocalStorage;
using IdentityManagment.UI.Client.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace IdentityManagment.UI.Client
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
            private readonly ILocalStorageService localStorageService;
            private ClaimsPrincipal anonymous = new ClaimsPrincipal(new ClaimsIdentity());
            public CustomAuthenticationStateProvider(ILocalStorageService localStorageService)
            {
                this.localStorageService = localStorageService;
            }
            public async override Task<AuthenticationState> GetAuthenticationStateAsync()
            {
                try
                {
                    var authenticationModel = await localStorageService.GetItemAsStringAsync("Authentication");
                    if (authenticationModel == null) { return await Task.FromResult(new AuthenticationState(anonymous)); }
                    return await Task.FromResult(new AuthenticationState(SetClaims(Deserialize(authenticationModel).Token!)));
                }
                catch
                {
                    return await Task.FromResult(new AuthenticationState(anonymous));
                }
            }

            public async Task UpdateAuthenticationState(AuthenticationModel authenticationModel)
            {
                try
                {

                    ClaimsPrincipal claimsPrincipal = new();

                    if (authenticationModel is not null)
                    {
                        //claimsPrincipal = SetClaims(authenticationModel.UserName!);
                        claimsPrincipal = SetClaims(authenticationModel.Token!);
                        await localStorageService.SetItemAsStringAsync("Authentication", Serialize(authenticationModel));
                    }
                    else
                    {
                        await localStorageService.RemoveItemAsync("Authentication");
                        claimsPrincipal = anonymous;
                    }
                    NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
                }
                catch
                {
                    await Task.FromResult(new AuthenticationState(anonymous));
                }


            }
            private ClaimsPrincipal SetClaims(string token)
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(token);
                var claims = jwtSecurityToken.Claims;

                return new ClaimsPrincipal(new ClaimsIdentity(claims, "CustomAuth"));
            }
            private AuthenticationModel Deserialize(string serializeString) => JsonSerializer.Deserialize<AuthenticationModel>(serializeString)!;
            private string Serialize(AuthenticationModel model) => JsonSerializer.Serialize(model);

        }
    }

