using Application.Interfaces.Repositories;
using Application.Interfaces;
using Application.Wrappers;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Entities;
using Core.Security.Hashing;
using Domain.Entities;

namespace Application.Features.Users.UserRegisterCommand
{
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommandRequest, Response<UserRegisterCommandResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IOperatorRepository _operatorRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        public UserRegisterCommandHandler(IUserRepository userRepository, IOperationClaimRepository operationClaimRepository, ITokenHelper tokenHelper, IRefreshTokenRepository refreshTokenRepository, IOperatorRepository operatorRepository, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userRepository = userRepository;
            _operationClaimRepository = operationClaimRepository;
            _tokenHelper = tokenHelper;
            _refreshTokenRepository = refreshTokenRepository;
            _operatorRepository = operatorRepository;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<Response<UserRegisterCommandResponse>> Handle(UserRegisterCommandRequest request, CancellationToken cancellationToken)
        {
            var userToCheck = await _userRepository.GetAsync(u => u.Email == request.Email);
            if (userToCheck == null)
            {
                byte[] passwordHash;
                byte[] passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                var user = new User();
                user.FirstName = request.FirstName;
                user.Status = true;
                user.LastName = request.LastName;
                user.Email = request.Email;
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                var addedUser = await _userRepository.AddAsync(user);
                var operatorr = new Operator(userId: addedUser.Id);
                var addedOperator = await _operatorRepository.AddAsync(operatorr);
                var userOperationClaim = new UserOperationClaim(userId:addedUser.Id , operationClaimId: 1 );
                await _userOperationClaimRepository.AddAsync( userOperationClaim );
                var roles = await _operationClaimRepository.GetListAsync(x => x.UserOperationClaims.Any(y => y.UserId == addedUser.Id));
                var accessToken = _tokenHelper.CreateToken(addedUser, roles.ToList());
                var refreshToken = _tokenHelper.CreateRefreshToken(addedUser);
                RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
                var responseData = new UserRegisterCommandResponse(
                        accessToken: accessToken.Token,
                        accessTokenExpiration: accessToken.Expiration,
                        refreshToken: refreshToken.Token,
                        refreshTokenExpiration: refreshToken.Expires
                    );
                return new Response<UserRegisterCommandResponse>(responseData);
            }
            return new Response<UserRegisterCommandResponse>("this user already exists");
        }
    }
}
