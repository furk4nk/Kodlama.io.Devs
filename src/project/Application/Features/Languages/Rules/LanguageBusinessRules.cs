using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;

namespace Application.Features.Languages.Rules
{
    public class LanguageBusinessRules
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageBusinessRules(ILanguageRepository languageRepository)
        {
            _languageRepository=languageRepository;
        }

        public async Task LanguageNameCanNotBeDuplicateWhenInserted(string name)
        {
            IPaginate<Domain.Entities.Language> language = await _languageRepository.GetListAsync(x => x.Name == name);
            if (language.Items.Any()) throw new BusinessException($"{name} Sistemde Kayıtlı");
        }

        public async Task LanguageShouldExistWhenRequested(int Id)
        {
            IPaginate<Domain.Entities.Language> language = await _languageRepository.GetListAsync(x => x.Id == Id);
            if (!language.Items.Any()) throw new BusinessException($"{Id} numaralı Veri Sistemde Bulunamadı");
        }

        public async Task LanguageNameCanNotBeDublicateWhenUpdated(string name, int Id)
        {
            await LanguageShouldExistWhenRequested(Id);
            await LanguageNameCanNotBeDuplicateWhenInserted(name);
        }
    }
}