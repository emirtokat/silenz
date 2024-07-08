using Application.Behaviours;
using Application.Features.Dtos;
using Application.Features.Form.Commands.Response;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FormQuestions
{
    public class CreateFormQuestionCommandRequest : IRequest<Response<CreateFormQuestionCommandResponse>>
    {
        public int FormId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string[] Roles { get; } = { "Operator", };

    }
}
