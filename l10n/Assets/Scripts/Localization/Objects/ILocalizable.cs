using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace l10n.Localization
{
    /// <summary>
    /// Implemented by Localizable Components.
    /// </summary>
    public interface ILocalizable
    {
        /// <summary>
        /// Updates the Value according to the current locale <see cref="ILocalizationObservable.CurrentLocale"/>
        /// </summary>
        void UpdateValue();
    }
}