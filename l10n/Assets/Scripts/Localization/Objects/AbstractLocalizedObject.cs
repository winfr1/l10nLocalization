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
        protected string key;

        private ILocalizationProvider s_provider;

        protected ILocalizationProvider Provider => s_provider ?? (s_provider = l10nDependencyProvider.Instance.Provider);

        protected override void OnLocaleChanged(object sender, ILocaleChangedEventArgs args)
        {
            UpdateValue();
        }

        public abstract void UpdateValue();
    }
}