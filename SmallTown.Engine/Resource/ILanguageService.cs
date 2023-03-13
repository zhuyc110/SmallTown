using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Engine.Resource
{
    public interface ILanguageService
    {
        public string CurrentLanguage { get; }

        public IReadOnlyCollection<string> SupportedLanguages { get; }
    }
}
