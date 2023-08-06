using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Queries.GetById
{
    public class GetByIdLanguageQuery : IRequest<GetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQuery, GetByIdDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly LanguageBusinessRules _languageBusinessRules;
            private readonly IMapper _mapper;

            public GetByIdLanguageQueryHandler(ILanguageRepository languageRepository, LanguageBusinessRules languageBusinessRules, IMapper mapper)
            {
                _languageRepository=languageRepository;
                _languageBusinessRules=languageBusinessRules;
                _mapper=mapper;
            }

            public async Task<GetByIdDto> Handle(GetByIdLanguageQuery request, CancellationToken cancellationToken)
            {
                await _languageBusinessRules.LanguageShouldExistWhenRequested(request.Id);

                Domain.Entities.Language language = await _languageRepository.GetAsync(x => x.Id == request.Id);
                GetByIdDto mappedLanguage = _mapper.Map<GetByIdDto>(language);

                return mappedLanguage;
            }
        }

    }
}
