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
    public class GetAllFormsQueryRequestHandler : IRequestHandler<GetAllFormsQueryRequest, Response<GetAllFormsQueryResponse>>
    {
        private readonly IFormRepository _formRepository;

        public GetAllFormsQueryRequestHandler(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public async Task<Response<GetAllFormsQueryResponse>> Handle(GetAllFormsQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GetAllFormsQueryResponse();
            var forms = await _formRepository.GetAllAsyncWithIncludes();
            response.Forms = forms;
            return new Response<GetAllFormsQueryResponse>(response);

        }
    }
}
