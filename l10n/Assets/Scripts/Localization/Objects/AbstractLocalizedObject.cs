using l10n.Localization.observables;
using l10n.Localization.provider;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace l10n.Localization.objects
{
    /// <summary>
    /// Implementation to localize GameObjects
    /// </summary>
    public abstract class AbstractLocalizedObject : AbstractLocalizationObserver, ILocalizable
    {
        [SerializeField]
        [Tooltip("The key used to identify the translation.")]
        protected string key;

        private ILocalizationProvider m_provider;

        protected ILocalizationProvider Provider => m_provider ?? (m_provider = l10nDependencyProvider.Provider);

        protected override void OnLocaleChanged(ILocaleChangedEventArgs args)
        {
            UpdateValue();
        }

        protected void OnEnable()
        {
            UpdateValue();
        }

        public abstract void UpdateValue();
    }
}