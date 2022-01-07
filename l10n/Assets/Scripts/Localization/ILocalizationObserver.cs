using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace l10n.Localization
{
    /// <summary>
    /// Observes <see cref="ILocalizationObservable"/> for changes in the current Locale. 
    /// </summary>
    internal interface ILocalizationObserver
    {
        /// <summary>
        /// Executed when the current Locale Changes.
        /// </summary>
        /// <param name="args">args with the latest changes will be passed <see cref="ILocaleChangedEventArgs"/></param>
        void OnLocaleChanged(ILocaleChangedEventArgs args);
    }
}