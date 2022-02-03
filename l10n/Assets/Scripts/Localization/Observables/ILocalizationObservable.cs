using l10n.common;
using l10n.Localization.observables;
using l10n.Localization.provider;
using System;
using System.Collections.Generic;

namespace l10n.Localization
{
    /// <summary>
    /// Provides Methods for Observable Localization Object. 
    /// <see cref="ILocalizationObserver"/> registers to this Interface.
    /// </summary>
    public interface ILocalizationObservable
    {
        /// <summary>
        /// Reference to <see cref="ILocalizationLogger"/> object that logs events to the console.
        /// </summary>
        ILocalizationLogger Logger { get; }

        /// <summary>
        /// Callback when the currently selected Locale <see cref="CurrentLocale"/> changes. 
        /// </summary>
        event Action<ILocaleChangedEventArgs> LocaleChanged;

        /// <summary>
        /// Current State of the object.
        /// </summary>
        LocalizationObservableState State { get; }

        /// <summary>
        /// Callback when the <see cref="LocalizationObservableState"/> Changes
        /// </summary>
        event Action<LocalizationObservableState> StateChanged;

        /// <summary>
        /// Returns all available Languages for this application.
        /// </summary>
        IList<string> AvailableLanguages { get; }

        /// <summary>
        /// Registers new Language to <see cref="AvailableLanguages"/> 
        /// </summary>
        /// <param name="locale">Language to register</param>
        void RegisterLanguage(string locale);

        /// <summary>
        /// Removes Language from <see cref="AvailableLanguages"/> 
        /// </summary>
        /// <param name="locale">Language to remove</param>
        void RemoveLanguage(string locale);

        /// <summary>
        /// The currently selected language setting.
        /// </summary>
        string CurrentLocale { get; }

        /// <summary>
        /// Loads a new application language.
        /// </summary>
        /// <param name="newLocale">Language to be loaded</param>
        void SetLocale(string newLocale, bool forceReload = false);
    }
}