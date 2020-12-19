using System.Globalization;

namespace RadFramework.Libraries.TextTranslation.Abstrations
{
    public interface ITranslationProvider
    {
        string Translate(string key, CultureInfo cultureInfo);
    }
}