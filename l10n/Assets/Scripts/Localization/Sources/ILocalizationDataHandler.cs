using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace l10n.Localization.sources
{
    /// <summary>
    /// Basis for Data Sources used by <see cref=""/>
    /// </summary>
    public interface ILocalizationDataHandler
    {
        /// <summary>
        /// Reloads the translations for the given locale.
        /// </summary>
        /// <param name="locale">The locale that should be loaded</param>
        void LoadTranslations(string locale);

    }
}