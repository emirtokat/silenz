using Application.Features.Form.Queries.Response;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Form.Queries.Request
{
    public class GetFormByIdQueryRequest : IRequest<Response<GetFormByIdQueryResponse>>
    {
        public int Id { get; set; }
    }

}
