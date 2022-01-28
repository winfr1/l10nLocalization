using System.Collections;
using UnityEngine;

namespace l10n.Localization.observables
{
    /// <summary>
    /// State for an <see cref="ILocalizationObservable"/> Object
    /// </summary>
    public enum LocalizationObservableState
    {
        Initializing,
        LocaleChanged,
        LoadingLocale,
        LocaleLoaded,
    }
}