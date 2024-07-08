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
    public class GetOperatorByIdQueryRequestHandler : IRequestHandler<GetOperatorByIdQueryRequest, Response<GetOperatorByIdQueryResponse>>
    {
        private readonly IOperatorRepository _operatorRepository;

        public GetOperatorByIdQueryRequestHandler(IOperatorRepository operatorRepository)
        {
            _operatorRepository = operatorRepository;
        }

        public async Task<Response<GetOperatorByIdQueryResponse>> Handle(GetOperatorByIdQueryRequest request, CancellationToken cancellationToken)
        {
     
            var response = new GetOperatorByIdQueryResponse();
            var operatorr = await _operatorRepository.GetAsyncWithIncludes(f => f.Id == request.Id);
            response.Operator = operatorr;
            return new Response<GetOperatorByIdQueryResponse>(response);

        }
    }
}
