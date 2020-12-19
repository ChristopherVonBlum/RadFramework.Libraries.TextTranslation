using System.Globalization;
using NUnit.Framework;
using RadFramework.Libraries.TextTranslation;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void TranslateFallbackToKey()
        {
            TranslationProvider provider = 
                new TranslationProvider(
                    new TranslationDictionaryFileLoader("TranslateFallbackToKey.json"));

            var okString = provider.Translate("key", new CultureInfo("en-US"));
            
            Assert.IsTrue(okString == "key");
        }

        [Test]
        public void Translate()
        {
            TranslationProvider provider = 
                new TranslationProvider(
                    new TranslationDictionaryFileLoader("Tests.json"));

            var okString = provider.Translate("ok", new CultureInfo("en-US"));
            
            Assert.IsTrue(okString == "ok string");
        }

        [Test]
        public void TranslateWithParentCultureFallback()
        {
            TranslationProvider provider = 
                new TranslationProvider(
                    new TranslationDictionaryFileLoader("ParentFallbackTests.json"));

            var okString = provider.Translate("ok", new CultureInfo("en-US"));
            
            Assert.IsTrue(okString == "ok string");
        }
        
        [Test]
        public void TranslateWithFallbackChain()
        {
            TranslationProvider provider = 
                new TranslationProvider(
                    new TranslationDictionaryFileLoader("ParentFallbackTests.json"), new []{ new CultureInfo("en") });

            var okString = provider.Translate("ok", new CultureInfo("de-DE"));
            
            Assert.IsTrue(okString == "ok string");
        }
    }
}