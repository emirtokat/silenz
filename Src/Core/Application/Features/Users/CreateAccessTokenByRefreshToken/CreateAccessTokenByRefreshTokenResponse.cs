using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.CreateAccessTokenByRefreshToken
{
    public class CreateAccessTokenByRefreshTokenResponse
    {
        public CreateAccessTokenByRefreshTokenResponse(string accessToken, DateTime accessTokenExpiration)
        {
            AccessToken = accessToken;
            AccessTokenExpiration = accessTokenExpiration;
        }

        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
    }
}