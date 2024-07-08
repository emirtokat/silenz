using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.UserLoginCommand
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommandRequest, Response<UserLoginCommandResponse>>
    {
        private readonly IOperatorRepository _operatorRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserRepository _userRepository;

        public UserLoginCommandHandler(IRefreshTokenRepository refreshTokenRepository, IOperatorRepository operatorRepository, IOperationClaimRepository operationClaimRepository, ITokenHelper tokenHelper, IUserRepository userRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _operatorRepository = operatorRepository;
            _operationClaimRepository = operationClaimRepository;
            _tokenHelper = tokenHelper;
            _userRepository = userRepository;
        }

        public async Task<Response<UserLoginCommandResponse>> Handle(UserLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var usertocheck = await _userRepository.GetAsync(u => u.Email == request.Email);
            if (usertocheck != null)
            {
                if (HashingHelper.VerifyPasswordHash(request.Password, usertocheck.PasswordHash, usertocheck.PasswordSalt))
                {
                    var roles = await _operationClaimRepository.GetListAsync(x => x.UserOperationClaims.Any(y => y.UserId == usertocheck.Id));
                    var accessToken = _tokenHelper.CreateToken(usertocheck, roles.ToList());
                    var refreshToken = await _refreshTokenRepository.GetAsync(x => x.UserId == usertocheck.Id);
                    if (refreshToken == null || refreshToken.Expires < DateTime.Now)
                    {
                        refreshToken =  await _refreshTokenRepository.AddAsync(_tokenHelper.CreateRefreshToken(usertocheck));
                    }
                    var responseData = new UserLoginCommandResponse(
                    accessToken: accessToken.Token,
                    accessTokenExpiration: accessToken.Expiration,
                    refreshToken: refreshToken.Token,
                    refreshTokenExpiration: refreshToken.Expires
                    );
                    return new Response<UserLoginCommandResponse>(responseData);
                }
            }
            return new Response<UserLoginCommandResponse>("Somethings have gone wrong");
        }
    }
}
