using l10n.Localization.observables;
using UnityEngine;
using System;

namespace l10n.Localization
{

    public abstract class AbstractLocalizationObserver : MonoBehaviour
    {
        [NonSerialized]
        private ILocalizationObservable s_observable;

        protected ILocalizationObservable Observable => s_observable ?? (s_observable = l10nDependencyProvider.Instance.Observable);

        #region Lifecycle
        protected virtual void Awake()
        {
            Observable.LocaleChanged += OnLocaleChanged;
        }

        protected virtual void OnDisable()
        {
            Observable.LocaleChanged -= OnLocaleChanged;
        }

        #endregion

        /// <summary>
        /// Reacts to the Change of the Locale Settings in <see cref="ILocalizationObservable.CurrentLocale"/>
        /// </summary>
        /// <param name="sender">Caller of this method</param>
        /// <param name="args">New Locale information</param>
        protected abstract void OnLocaleChanged(object sender, ILocaleChangedEventArgs args);
    }
}