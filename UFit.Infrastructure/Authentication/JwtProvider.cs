﻿using System.Net.Http.Json;
using System.Text.Json.Serialization;
using UFit.Application.Abstractions.Authentication;

namespace UFit.Infrastructure.Authentication;
internal sealed class JwtProvider : IJwtProvider
{
    private readonly HttpClient _httpClient;

    public JwtProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetJwtAsync(string email, string password)
    {
        // TODO: Handle 404 or 403
        var request = new
        {
            email,
            password,
            returnSecureToken = true
        };

        var response = await _httpClient.PostAsJsonAsync("", request);

        var authToken = await response.Content.ReadFromJsonAsync<AuthToken>();

        return authToken.IdToken;
    }

    public class AuthToken
    {
        [JsonPropertyName("idToken")]
        public string IdToken { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
        [JsonPropertyName("expiresIn")]
        public string ExpiresIn { get; set; }
        [JsonPropertyName("localId")]
        public string LocalId { get; set; }
        [JsonPropertyName("registered")]
        public bool Registered { get; set; }
    }
}
