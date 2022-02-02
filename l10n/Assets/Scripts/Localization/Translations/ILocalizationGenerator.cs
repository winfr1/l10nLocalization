using System.Collections;
using UnityEngine;

namespace l10n.Localization.translations
{
    /// <summary>
    /// Provides Methods for generating Translations <see cref="AbstractTranslation"/>
    /// </summary>
    public interface ILocalizationGenerator
    {
        /// <summary>
        /// Generate Translation Object from given Key and Value.
        /// </summary>
        /// <param name="locale">Locale that is loaded</param>
        AbstractTranslation GenerateTranslation<T>(string key, string locale, T value, object owner);

    }
}