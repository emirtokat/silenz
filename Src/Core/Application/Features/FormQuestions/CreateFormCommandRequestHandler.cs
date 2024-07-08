
using AutoMapper;
using MediatR;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Wrappers;
using Application.Features.Form.Commands.Response;
using Application.Interfaces;
using Application.Features.Users.UserRegisterCommand;
using Application.Interfaces.Repositories;
using Core.Security.Entities;
using Application.Behaviours;

namespace Application.Features.FormQuestions

{
    public class CreateFormQuestionCommandHandler : IRequestHandler<CreateFormQuestionCommandRequest, Response<CreateFormQuestionCommandResponse>> 
    {
        private readonly IQuestionRepository _questionRepository;

        public CreateFormQuestionCommandHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }


        public async Task<Response<CreateFormQuestionCommandResponse>> Handle(CreateFormQuestionCommandRequest request, CancellationToken cancellationToken)
        {
            var question = new Domain.Entities.Question();
            question.Title = request.Title;
            question.FormId = request.FormId;
            question.Type = request.Type;
            var addedQuestion = await _questionRepository.AddAsync(question);
            var response = new CreateFormQuestionCommandResponse();
            response.Id = addedQuestion.Id;
            return new Response<CreateFormQuestionCommandResponse>(response);
        }
    }
}
