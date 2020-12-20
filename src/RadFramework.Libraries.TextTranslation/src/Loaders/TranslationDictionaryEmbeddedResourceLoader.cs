using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using RadFramework.Libraries.TextTranslation.Abstractions;

namespace RadFramework.Libraries.TextTranslation.Loaders
{
    public class TranslationDictionaryEmbeddedResourceLoader : ITranslationDictionaryLoader
    {
        private readonly Assembly _assembly;
        private readonly string _resourceName;

        public TranslationDictionaryEmbeddedResourceLoader(Assembly assembly, string resourceName)
        {
            _assembly = assembly;
            _resourceName = resourceName;
        }
        
        public IEnumerable<TranslationDictionary> LoadDictionaries()
        {
            using (StreamReader sr = new StreamReader(_assembly.GetManifestResourceStream(_resourceName)))
            {
                return JsonConvert.DeserializeObject<TranslationDictionary[]>(sr.ReadToEnd());
            }
        }
    }
}