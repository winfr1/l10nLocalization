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
        private string m_key;

        public string Key
        {
            get => m_key;
            set
            {
                m_key = value;
                UpdateValue();
            }
        }

        private ILocalizationProvider m_provider;

        protected ILocalizationProvider Provider => m_provider ?? (m_provider = l10nDependencyProvider.Provider);

        protected override void OnLocaleChanged(ILocaleChangedEventArgs args)
        {
            UpdateValue();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            UpdateValue();
        }

        public abstract void UpdateValue();
    }
}