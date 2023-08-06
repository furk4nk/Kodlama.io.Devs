using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Languages.Commands.UpdateLanguage
{
    public class UpdateLanguageCommand : IRequest<UpdateLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, UpdateLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly LanguageBusinessRules _languageBusinessRules;
            private readonly IMapper _mapper;

            public UpdateLanguageCommandHandler(ILanguageRepository languageRepository, LanguageBusinessRules languageBusinessRules, IMapper mapper)
            {
                _languageRepository=languageRepository;
                _languageBusinessRules=languageBusinessRules;
                _mapper=mapper;
            }

            public async Task<UpdateLanguageDto> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
            {
                await _languageBusinessRules.LanguageNameCanNotBeDublicateWhenUpdated(request.Name, request.Id);

                Domain.Entities.Language requestLanguage = _mapper.Map(request,await _languageRepository.GetAsync(x => x.Id==request.Id));
                Domain.Entities.Language updatedLanguage =_languageRepository.Update(requestLanguage);
                UpdateLanguageDto updateLanguageDto = _mapper.Map<UpdateLanguageDto>(updatedLanguage);
                return updateLanguageDto;
            }
        }
    }
}
