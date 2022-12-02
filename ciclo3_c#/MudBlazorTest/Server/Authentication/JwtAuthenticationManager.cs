using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MudBlazorTest.Server.Authentication
{
    public class JwtAuthenticationManager
    {
        public const string JWT_SECURITY_KEY = "oLIY0UAqFugq3f2rX2TsBhZUD2HiriNF0oDEZTGf8pNGvBKYRFg88AN0XTVUiZH";
        //after 20mins JWT will no longer be valid, even the signuter is correct and everything is matched.
        public const int JWT_TOKEN_VALAIDITY_MINS = 20;

        private UserAccountService _userAccountService;

        public JwtAuthenticationManager(UserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        public UserSession? GenerateJwtToken(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                return null;

            // Validating the User Credentials
            var userAccount = _userAccountService.GetUserAccountByUserName(userName);
            if (userAccount == null || userAccount.Password != password)
                return null;

            // Generating JWT Token
            var tokenExpiricyTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALAIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, userAccount.UserName),
                new Claim(ClaimTypes.Role, userAccount.Role)
            });
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiricyTimeStamp,
                NotBefore = DateTime.Now,
                SigningCredentials = signingCredentials,
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            // Returning the User Session object
            var userSession = new UserSession
            {
                UserName = userAccount.UserName,
                Role = userAccount.Role,
                Token = token,
                ExpiresIn = (int)tokenExpiricyTimeStamp.Subtract(DateTime.Now).TotalSeconds
            };
            return userSession;
        }
    }
}
