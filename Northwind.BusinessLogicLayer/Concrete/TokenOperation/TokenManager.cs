using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Northwind.EntityLayer.Concrete.Dtos.DtoTokenOperations;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Northwind.BusinessLogicLayer.Concrete.TokenOperation
{
    public class TokenManager
    {
        private readonly IConfiguration _configuration;

        public TokenManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateAccessToken(DtoLoginUser dtoUser)
        {
            var claims = new[]
            {
                //Todo : claims oluşturmak.
                new Claim(JwtRegisteredClaimNames.Sub, dtoUser.Email),
                //new Claim(JwtRegisteredClaimNames.Sub, dtoUser.UserCode),
                new Claim(JwtRegisteredClaimNames.Jti, dtoUser.UserId.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Token");

            var claimsRoleList = new List<Claim>
            {   
                //Todo : claims roller
                new Claim("role", "a")
            };

            //Todo : Scurity key'in simetriğini alıyoruz.
            var t = Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]);
            var key = new SymmetricSecurityKey(t);

            //Todo : Şifrelenmiş kimlik oluşturuluyor.

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Todo : Token ayarlarını oluşturuyoruz.

            var token = new JwtSecurityToken
            (
                issuer: _configuration["Tokens:Issuer"], //token dağıtıcı url
                audience: _configuration["Tokens:Issuer"], //erişilebilecek apiler
                expires: DateTime.Now.AddMinutes(5), //token süresini 5 dk verdik.
                notBefore: DateTime.Now, //tokenın ne zaman devreye gireceğini söyledik.
                signingCredentials: credentials, //kimlik verildi.
                claims: claimsIdentity.Claims //roller verildi
            );

            var tokenHandler = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return tokenHandler.token;
        }
    }
}
