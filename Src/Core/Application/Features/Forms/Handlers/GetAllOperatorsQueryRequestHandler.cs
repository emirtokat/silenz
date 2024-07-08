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
    public class GetAllOperatorsQueryRequestHandler : IRequestHandler<GetAllOperatorsQueryRequest, Response<GetAllOperatorsQueryResponse>>
    {
        private readonly IOperatorRepository _operatorRepository;

        public GetAllOperatorsQueryRequestHandler(IOperatorRepository operatorRepository)
        {
            _operatorRepository = operatorRepository;
        }

        public async Task<Response<GetAllOperatorsQueryResponse>> Handle(GetAllOperatorsQueryRequest request, CancellationToken cancellationToken)
        {
     
            var response = new GetAllOperatorsQueryResponse();
            var operatorr = await _operatorRepository.GetAllAsyncWithIncludes();
            response.Operators= operatorr;
            return new Response<GetAllOperatorsQueryResponse>(response);

        }
    }
}
