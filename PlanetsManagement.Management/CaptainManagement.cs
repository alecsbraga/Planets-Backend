using Microsoft.IdentityModel.Tokens;
using PlanetsManagement.DataAccess;
using PlanetsManagement.DataContracts;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PlanetsManagement.Management
{
    public class CaptainManagement
    {
        CaptainRepository _captainRepository = new CaptainRepository();
        public ResponseDTO CheckPassword(CaptainDTO captain)
        {
            var repoResult = _captainRepository.GetCaptainByUsername(captain.username);
            if (repoResult != null)
            {
                if (repoResult.Password == captain.password)
                {
                    var token = CreateJwt(repoResult);
                    var response = new ResponseDTO
                    {
                        message = "Login successfully",
                        token = token

                    };
                    return response;
                }
                return new ResponseDTO { message = "Wrong passsword", token = "null" };

            }


            return new ResponseDTO { message = "Wrong username", token = "null"};
        }

        private string CreateJwt(Captain captain)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("jxnULdOGtJM1XhlaOi1PspkbXh5DrU123321....");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier,$"{captain.Id}"),
                new Claim(ClaimTypes.Name,$"{captain.Name}")
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
