using System.Globalization;

namespace RadFramework.Libraries.TextTranslation.Abstractions
{
    public interface ITranslationProvider
    {
        string Translate(string key, CultureInfo cultureInfo);
    }
}