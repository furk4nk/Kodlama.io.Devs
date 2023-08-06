using Application.Features.Languages.Models;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Languages.Queries.GetList
{
    public class GetListLanguageQuery : IRequest<GetListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListLanguageQueryHandler : IRequestHandler<GetListLanguageQuery, GetListModel>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly LanguageBusinessRules _languageBusinessRules;
            private readonly IMapper _mapper;

            public GetListLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
            {
                _languageRepository=languageRepository;
                _mapper=mapper;
                _languageBusinessRules=languageBusinessRules;
            }

            public async Task<GetListModel> Handle(GetListLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Domain.Entities.Language> languageList = await _languageRepository.GetListAsync(index:request.PageRequest.Page , size:request.PageRequest.PageSize);

                GetListModel mappedLanguageList = _mapper.Map<GetListModel>(languageList);

                return mappedLanguageList;
            }
        }
    }
}
