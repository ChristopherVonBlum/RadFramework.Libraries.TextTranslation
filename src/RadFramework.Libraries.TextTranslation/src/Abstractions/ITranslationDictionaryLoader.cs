using System.Collections.Generic;

namespace RadFramework.Libraries.TextTranslation.Abstractions
{
    public interface ITranslationDictionaryLoader
    {
        IEnumerable<TranslationDictionary> LoadDictionaries();
    }
}