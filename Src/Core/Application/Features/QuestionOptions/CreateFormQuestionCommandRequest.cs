using Application.Features.Dtos;
using Application.Features.Form.Commands.Response;
using Application.Features.QuestionOptions;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.QuestionOptions
{
    public class CreateQuestionOptCommandRequest : IRequest<Response<CreateQuestionOptCommandResponse>>
    {
        public int QuestionId { get; set; }
        public string Name { get; set; }
    }
}
