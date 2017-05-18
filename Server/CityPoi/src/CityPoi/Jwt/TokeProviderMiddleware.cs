using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Cryptography;
using CityPoi.DataAccesLayer;
using CityPoi.Services;

//code inspiré de : https://stormpath.com/blog/token-authentication-asp-net-core

namespace jwt_exemple.Jwt
{
    
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenProviderOptions _options;
        private IUserRepository _userRepository;

        public TokenProviderMiddleware(
            RequestDelegate next,
            IOptions<TokenProviderOptions> options,
            IUserRepository userRepository)
        {
            _next = next;
            _options = options.Value;
            _userRepository = userRepository;
        }

        public Task Invoke(HttpContext context)
        {
            // If the request path doesn't match, skip
            if (!context.Request.Path.Equals(_options.Path, StringComparison.Ordinal))
            {
                return _next(context);
            }

            // Request must be POST with Content-Type: application/x-www-form-urlencoded
            if (!context.Request.Method.Equals("POST")
               || !context.Request.HasFormContentType)
            {
                context.Response.StatusCode = 400;
                return context.Response.WriteAsync("Bad request.");
            }

            return GenerateToken(context);
        }

        private async Task GenerateToken(HttpContext context)
        {
            var username = context.Request.Form["username"];
            var password = context.Request.Form["password"];

            var claimsIdentity = await GetIdentity(username, password);

            if (claimsIdentity == null)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid username or password.");
                return;
            }

            var encodedJwt = CreateEncodedJwt(claimsIdentity);
            var httpResponse = CreateHttpResponse(encodedJwt);

            // Serialize and return the response
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(httpResponse, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        private object CreateHttpResponse(string encodedJwt)
        {
            return new
            {
                access_token = encodedJwt,
                expires_in = (int)_options.Expiration.TotalSeconds
            };
        }

        private string CreateEncodedJwt(ClaimsIdentity claimsIdentity)
        {
            var now = DateTime.UtcNow;

            // Specifically add the jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
            // You can add other claims here, if you want:
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, claimsIdentity.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(now).ToString(), ClaimValueTypes.Integer64),
            };

            var claimsIdentityRoles = claimsIdentity.Claims.Where(c => c.Type == ClaimTypes.Role).ToArray();
            var allClaims = claims.Concat(claimsIdentityRoles).ToArray();

            // Create the JWT and write it to a string
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: allClaims,
                notBefore: now,
                expires: now.Add(_options.Expiration),
                signingCredentials: _options.SigningCredentials);

            var jwtEncodedToken = new JwtSecurityTokenHandler().WriteToken(jwt);
            return jwtEncodedToken;
        }

        private Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            var hashPassword = GetHashString(password);

            if (_userRepository.IsValid(username, hashPassword))
            {
                return Task.FromResult(
                    new ClaimsIdentity(
                        new GenericIdentity(username, "Token"),
                        new Claim[]
                        {
                            new Claim(ClaimTypes.Role, _userRepository.getRole(username)),
                        }));
            }

            // Credentials are invalid, or account doesn't exist
            return Task.FromResult<ClaimsIdentity>(null);
        }

        public static long ToUnixEpochDate(DateTime date) => new DateTimeOffset(date).ToUniversalTime().ToUnixTimeSeconds();



        private static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();  
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        private static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }

}
