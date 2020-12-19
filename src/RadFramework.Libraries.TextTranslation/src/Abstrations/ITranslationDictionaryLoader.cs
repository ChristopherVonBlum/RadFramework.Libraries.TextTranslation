using System.Collections.Generic;

namespace RadFramework.Libraries.TextTranslation.Abstrations
{
    public interface ITranslationDictionaryLoader
    {
        IEnumerable<TranslationDictionary> LoadDictionaries();
    }
}