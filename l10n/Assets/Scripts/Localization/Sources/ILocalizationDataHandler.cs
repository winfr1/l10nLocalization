using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        Task LoadTranslations();

        /// <summary>
        /// Loads the Locale Name from the Data Source
        /// </summary>
        void LoadLocaleName();

    }
}