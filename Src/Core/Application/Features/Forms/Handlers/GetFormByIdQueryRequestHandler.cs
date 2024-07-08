using Application.Features.Form.Queries.Request;
using Application.Features.Form.Queries.Response;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Features.Form.Handlers
{
    public class GetFormByIdQueryRequestHandler : IRequestHandler<GetFormByIdQueryRequest, Response<GetFormByIdQueryResponse>>
    {
        private readonly IFormRepository _formRepository;
        private readonly IUserRepository _userRepository;

        public GetFormByIdQueryRequestHandler(IFormRepository formRepository, IUserRepository userRepository)
        {
            _formRepository = formRepository;
            _userRepository = userRepository;
        }

        public async Task<Response<GetFormByIdQueryResponse>> Handle(GetFormByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GetFormByIdQueryResponse();
            var form = await _formRepository.GetAsyncWithIncludes(f => f.Id == request.Id);
            if (form != null)
            {
                response.Questions = form.Questions;
                response.Title = form.Title;

                var user = await _userRepository.GetByIdAsync(form.Operator.UserId);
                response.OperatorName = user.FirstName;
                return new Response<GetFormByIdQueryResponse>(response);
            }
            return new Response<GetFormByIdQueryResponse>("böyle bir form yok");
        }
    }
}
