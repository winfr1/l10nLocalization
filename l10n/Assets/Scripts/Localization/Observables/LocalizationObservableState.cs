using System.Collections;
using UnityEngine;

namespace l10n.Localization.observables
{
    /// <summary>
    /// State for an <see cref="ILocalizationObservable"/> Object
    /// </summary>
    public enum LocalizationObservableState
    {
        /// <summary>
        /// Used when the scene is first started
        /// </summary>
        Initializing,

        /// <summary>
        /// Reflecting the loading process of a new language
        /// </summary>
        LoadingLocale,

        /// <summary>
        /// State when the <see cref="ILocalizationObservable"/> is initialized and the chosen language is loaded.
        /// </summary>
        LocaleLoaded,
    }
}