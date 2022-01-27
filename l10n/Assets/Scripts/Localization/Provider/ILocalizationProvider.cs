using l10n.Localization.translations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace l10n.Localization.provider
{
    /// <summary>
    /// Provides Localization Services for <see cref="ILocalizable"/> objects.
    /// </summary>
    public interface ILocalizationProvider
    {
        /// <summary>
        /// List of Translation Objects provided
        /// </summary>
        IList<AbstractTranslation> Translations { get; }

        /// <summary>
        /// Retrieves a translation for a given key. 
        /// </summary>
        /// <param name="key">The key mapped to the translation.</param>
        /// <returns>The translated object.</returns>
        AbstractTranslation Translate(string key);

        /// <summary>
        /// Registers a Translation from a <see cref="ILocalizationDataHandler"/> Object.
        /// </summary>
        /// <param name="key">Key to identify the translation</param>
        /// <param name="value">value of localization</param>
        /// <returns></returns>
        bool RegisterTranslation(string key, string locale, object value, object owner);
    }
}