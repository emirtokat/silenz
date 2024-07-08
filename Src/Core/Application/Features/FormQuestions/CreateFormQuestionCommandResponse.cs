using Application.Features.Dtos;
using Application.Features.Form.Commands.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FormQuestions
{
    public class CreateFormQuestionCommandResponse 
    {
        public int Id { get; set; }
    }
}
