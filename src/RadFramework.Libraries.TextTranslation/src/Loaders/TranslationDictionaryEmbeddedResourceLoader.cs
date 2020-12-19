using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using RadFramework.Libraries.TextTranslation.Abstractions;

namespace RadFramework.Libraries.TextTranslation.Loaders
{
    public class TranslationDictionaryEmbeddedResourceLoader : ITranslationDictionaryLoader
    {
        private readonly string _resourceName;

        public TranslationDictionaryEmbeddedResourceLoader(string resourceName)
        {
            _resourceName = resourceName;
        }
        
        public IEnumerable<TranslationDictionary> LoadDictionaries()
        {
            var assembly = Assembly.GetExecutingAssembly();
            
            using (StreamReader sr = new StreamReader(assembly.GetManifestResourceStream(_resourceName)))
            {
                return JsonConvert.DeserializeObject<TranslationDictionary[]>(sr.ReadToEnd());
            }
        }
    }
}