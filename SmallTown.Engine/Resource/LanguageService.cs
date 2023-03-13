using Microsoft.Extensions.Options;
using SmallTown.Config;

namespace SmallTown.Engine.Resource;

public class LanguageService : ILanguageService
{
    private const string DEFAULT_LANGUAGE = "zh-cn";

    public string CurrentLanguage { get; }

    public IReadOnlyCollection<string> SupportedLanguages { get;  }

    public LanguageService(IOptions<Settings> settings)
    {
        SupportedLanguages = settings.Value.I18n;
        CurrentLanguage = SupportedLanguages.FirstOrDefault() ?? DEFAULT_LANGUAGE;
    }
}
