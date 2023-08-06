using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Commands.DeleteLanguage
{
    public class DeleteLanguageCommand : IRequest<DeleteLanguageDto>
    {
        public int Id { get; set; }
        public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, DeleteLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly LanguageBusinessRules _languageBusinessRules;
            private readonly IMapper _mapper;

            public DeleteLanguageCommandHandler(ILanguageRepository languageRepository, LanguageBusinessRules languageBusinessRules, IMapper mapper)
            {
                _languageRepository=languageRepository;
                _languageBusinessRules=languageBusinessRules;
                _mapper=mapper;
            }

            public async Task<DeleteLanguageDto> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
            {
                await _languageBusinessRules.LanguageShouldExistWhenRequested(request.Id);

                var language = await _languageRepository.GetAsync(x => x.Id==request.Id);
                var deletedLanguage = await _languageRepository.DeleteAsync(language);
                DeleteLanguageDto deleteLanguageDto = _mapper.Map<DeleteLanguageDto>(deletedLanguage);

                return deleteLanguageDto;
            }
        }
    }
}
