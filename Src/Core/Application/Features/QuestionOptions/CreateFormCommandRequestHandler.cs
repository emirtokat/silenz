
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
using Application.Features.FormQuestions;

namespace Application.Features.QuestionOptions

{
    public class CreateQuestionOptionsCommandHandler : IRequestHandler<CreateQuestionOptCommandRequest, Response<CreateQuestionOptCommandResponse>>
    {
        private readonly IQuestionOptRepository _questionOptRepository;

        public CreateQuestionOptionsCommandHandler(IQuestionOptRepository questionOptRepository)
        {
            _questionOptRepository = questionOptRepository;
        }

        public async Task<Response<CreateQuestionOptCommandResponse>> Handle(CreateQuestionOptCommandRequest request, CancellationToken cancellationToken)
        {
            var questionOpt = new Domain.Entities.QuestionOpt();
            questionOpt.QuestionId = request.QuestionId;
            questionOpt.Name = request.Name;
            var addedQuestion = await _questionOptRepository.AddAsync(questionOpt);
            return new Response<CreateQuestionOptCommandResponse>("başarılı");
        }
    }
}
