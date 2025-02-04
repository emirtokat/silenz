﻿using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.CreateAccessTokenByRefreshToken
{
    public class CreateAccessTokenByRefreshTokenRequest : IRequest<Response<CreateAccessTokenByRefreshTokenResponse>>
    {
        public string Token { get; set; }

    }
}
