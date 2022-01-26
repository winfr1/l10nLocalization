using l10n.common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace l10n.Localization.provider
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
        event EventHandler<ILocaleChangedEventArgs> LocaleChanged;

        /// <summary>
        /// The currently selected language setting.
        /// </summary>
        string CurrentLocale { get; set; }

    }
}