using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace l10n.Localization
{
    /// <summary>
    /// Provides Methods for Observable Localization Object. 
    /// <see cref="ILocalizationObserver"/> registers to this Interface.
    /// </summary>
    internal interface ILocalizationObservable
    {
        /// <summary>
        /// Callback when the currently selected Locale <see cref="CurrentLocale"/> changes. 
        /// </summary>
        event EventHandler<ILocaleChangedEventArgs> LocaleChanged;

        string CurrentLocale { get; set; }

    }
}