using l10n.common;
using l10n.Localization.observables;
using l10n.Localization.provider;
using l10n.Localization.translations;
using UnityEngine;

namespace l10n.Localization
{
    /// <summary>
    /// Provides References to all the important classes in the framework.
    /// </summary>
    [ExecuteAlways]
    public static class l10nDependencyProvider
    {

        public const string MenuPrefix = "Localization/";

        [SerializeField]
        private static ILocalizationObservable m_observable;
        public static ILocalizationObservable Observable => m_observable ?? (m_observable = l10nManager.Instance);

        [SerializeField]
        private static ILocalizationProvider m_provider;
        public static ILocalizationProvider Provider => m_provider ?? (m_provider = LocalizationProvider.Instance);
        
    }
}