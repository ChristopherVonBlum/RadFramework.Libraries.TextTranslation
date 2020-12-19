using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using RadFramework.Libraries.TextTranslation.Abstractions;

namespace RadFramework.Libraries.TextTranslation
{
    public class TranslationProvider : ITranslationProvider
    {
        private readonly IEnumerable<CultureInfo> _fallbackCultures;
        private Dictionary<CultureInfo, TranslationDictionary> dictionary;
        
        
        public TranslationProvider(ITranslationDictionaryLoader loader) : this(loader, new CultureInfo[0])
        {
        }
        
        public TranslationProvider(ITranslationDictionaryLoader loader, IEnumerable<CultureInfo> fallbackCultures)
        {
            _fallbackCultures = fallbackCultures;
            dictionary = loader
                .LoadDictionaries()
                .GroupBy(d => d.Culture)
                .Select(d =>
                    new TranslationDictionary
                    {
                        Culture = d.Key,
                        Dictionary = d
                            .SelectMany(v => v.Dictionary)
                            .ToDictionary(k => k.Key, v => v.Value)
                    })
                .ToDictionary(k => k.Culture);
        }
        
        public string Translate(string key, CultureInfo cultureInfo)
        {
            CultureInfo resolved = ResolveCulture(key, cultureInfo);

            if (resolved == null)
            {
                return key;
            }

            return dictionary[resolved].Dictionary[key];
        }

        private CultureInfo ResolveCulture(string key, CultureInfo cultureInfo)
        {
            if (dictionary.ContainsKey(cultureInfo)
                && dictionary[cultureInfo].Dictionary.ContainsKey(key))
            {
                return cultureInfo;
            }

            if (dictionary.ContainsKey(cultureInfo.Parent)
                && dictionary[cultureInfo.Parent].Dictionary.ContainsKey(key))
            {
                return cultureInfo.Parent;
            }

            foreach (var culture in _fallbackCultures)
            {
                if (dictionary.ContainsKey(culture) &&
                    dictionary[culture].Dictionary.ContainsKey(key))
                {
                    return culture;
                }
            }

            return null;
        }
    }
}