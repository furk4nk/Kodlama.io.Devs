using Application.Features.Language.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Commands.CreateLanguage
{
    public class CreateLanguageCommand : IRequest<CreateLanguageDto>
    {
        public string Name { get; set; }
        public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, CreateLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly LanguageBusinessRules _languageBusinessRules;
            private readonly IMapper _mapper;

            public CreateLanguageCommandHandler(ILanguageRepository languageRepository, LanguageBusinessRules languageBusinessRules, IMapper mapper)
            {
                _languageRepository=languageRepository;
                _languageBusinessRules=languageBusinessRules;
                _mapper=mapper;
            }

            public async Task<CreateLanguageDto> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
            {

                await _languageBusinessRules.LanguageNameCanNotBeDuplicateWhenInserted(request.Name);

                var language = _mapper.Map<Domain.Entities.Language>(request);
                var createdLanguage = await _languageRepository.AddAsync(language);
                var mappedLanguage = _mapper.Map<CreateLanguageDto>(createdLanguage);
                return mappedLanguage;
            }
        }
    }
}
