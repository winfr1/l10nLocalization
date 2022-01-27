using l10n.common;
using l10n.Localization.provider;
using System.Collections;
using UnityEngine;

namespace l10n.Localization
{
    public sealed class l10nDependencyProvider : Singleton<l10nDependencyProvider>
    {
        /// <summary>
        /// protected constructor to prevent instantiation
        /// </summary>
        private l10nDependencyProvider() { }

        private ILocalizationGenerator s_manager;

        private ILocalizationObservable s_observable:

        private ILocalizationProvider s_provider;

        public ILocalizationGenerator Manager => s_manager;

    }
}