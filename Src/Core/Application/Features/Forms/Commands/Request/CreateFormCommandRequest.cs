using Application.Behaviours;
using Application.Features.Dtos;
using Application.Features.Form.Commands.Response;
using Application.Features.Form.Queries.Request;
using Application.Wrappers;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Form.Commands.Request
{
    public class CreateFormCommandRequest :IRequest<Response<CreateFormCommandResponse>>,ISecuredRequest
    {
        public FormDTO FormDTO { get; set; }
        public string[] Roles { get; } = { "Operator", };
    }
}
