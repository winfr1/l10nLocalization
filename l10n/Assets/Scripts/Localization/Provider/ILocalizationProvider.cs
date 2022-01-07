using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace l10n.Localization.provider
{
    /// <summary>
    /// Provides Localization Services for <see cref="ILocalizable"/> objects.
    /// </summary>
    public interface ILocalizationProvider<out R>
    {
        /// <summary>
        /// Retrieves a translation for a given key. 
        /// </summary>
        /// <param name="key">The key mapped to the translation.</param>
        /// <returns>The translated object.</returns>
        R translate(string key);
    }
}