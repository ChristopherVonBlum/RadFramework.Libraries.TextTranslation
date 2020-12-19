using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RadFramework.Libraries.TextTranslation.Abstrations;

namespace RadFramework.Libraries.TextTranslation
{
    public class TranslationDictionaryFileLoader : ITranslationDictionaryLoader
    {
        private readonly string _path;

        public TranslationDictionaryFileLoader(string path)
        {
            _path = path;
        }
        
        public IEnumerable<TranslationDictionary> LoadDictionaries()
        {
            return JsonConvert.DeserializeObject<TranslationDictionary[]>(File.ReadAllText(_path));
        }
    }
}