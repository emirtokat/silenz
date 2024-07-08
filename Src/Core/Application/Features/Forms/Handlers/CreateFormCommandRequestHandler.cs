using Application.Features.Form.Commands.Request;
using Application.Features.Form.Commands.Response;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Wrappers;
using Application.Features.FormQuestions;

namespace Application.Features.Form.Handlers
{
    public class CreateFormCommandHandler : IRequestHandler<CreateFormCommandRequest, Response<CreateFormCommandResponse>>
    {
        private readonly IFormRepository _formRepository;
        private readonly IQuestionOptRepository _questionOptRepository;
        private readonly IMapper _mapper;

        public CreateFormCommandHandler(IFormRepository formRepository, IMapper mapper, IQuestionOptRepository questionOptRepository)
        {
            _formRepository = formRepository;
            _mapper = mapper;
            _questionOptRepository = questionOptRepository;
        }

        public async Task<Response<CreateFormCommandResponse>> Handle(CreateFormCommandRequest request, CancellationToken cancellationToken)
        {
            var form = new Domain.Entities.Form();
            form.Title = request.FormDTO.Title;
            form.OperatorId = request.FormDTO.OperatorId;
            var addedForm = await _formRepository.AddAsync(form);
            var response = new CreateFormCommandResponse();
            response.Id = addedForm.Id;
            return new Response<CreateFormCommandResponse>(response);
        }
    }
}
