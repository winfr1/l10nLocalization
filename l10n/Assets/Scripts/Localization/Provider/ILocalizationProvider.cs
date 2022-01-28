using l10n.Localization.sources;
using l10n.Localization.translations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        IList<ILocalizationDataHandler> DataHandlers { get; }

        /// <summary>
        /// Retrieves a translation for a given key. 
        /// </summary>
        /// <param name="key">The key mapped to the translation.</param>
        /// <returns>The translated object.</returns>
        AbstractTranslation Translate(string key);

        /// <summary>
        /// Loads all Translations from registered <see cref="ILocalizationDataHandler"/> asynchronously. 
        /// </summary>
        Task LoadTranslationsAsync(string locale);

        /// <summary>
        /// Unregisters <see cref="ILocalizationDataHandler"/> to this LocalizationProvider.
        /// </summary>
        /// <param name="handler"></param>
        void register(ILocalizationDataHandler handler);

        /// <summary>
        /// Unregisters <see cref="ILocalizationDataHandler"/> to this LocalizationProvider.
        /// </summary>
        /// <param name="handler"></param>
        void unregister(ILocalizationDataHandler handler);

        /// <summary>
        /// Registers a Translation from a <see cref="ILocalizationDataHandler"/> Object.
        /// </summary>
        /// <param name="key">Key to identify the translation</param>
        /// <param name="value">value of localization</param>
        /// <returns></returns>
        bool RegisterTranslation(string key, string locale, object value, object owner);
    }
}