using System.Collections;
using UnityEngine;

namespace l10n.Localization.provider
{
    /// <summary>
    /// State for the <see cref="LocalizationProvider"/>
    /// </summary>
    public enum LocalizationProviderState
    {
        /// <summary>
        /// <see cref="AbstractTranslation"/> objects are loading from <see cref="ILocalizationDataHandler"/>
        /// </summary>
        TranslationsLoading,

        /// <summary>
        /// Loading complete.
        /// </summary>
        TranslationsLoaded
    }
}