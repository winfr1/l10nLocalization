using l10n.Localization.observables;
using UnityEngine;
using System;

namespace l10n.Localization
{

    public abstract class AbstractLocalizationObserver : MonoBehaviour
    {
        [NonSerialized]
        private ILocalizationObservable m_observable;

        protected ILocalizationObservable Observable => m_observable ?? (m_observable = l10nDependencyProvider.Observable);

        #region Lifecycle
        protected virtual void OnEnable()
        {
            if (Application.isPlaying)
            {
                Observable.LocaleChanged += OnLocaleChanged;
            }            
        }

        protected virtual void OnDisable()
        {
            if (Application.isPlaying)
            {
                Observable.LocaleChanged -= OnLocaleChanged;
            }
        }

        #endregion

        /// <summary>
        /// Reacts to the Change of the Locale Settings in <see cref="ILocalizationObservable.CurrentLocale"/>
        /// </summary>
        /// <param name="sender">Caller of this method</param>
        /// <param name="args">New Locale information</param>
        protected abstract void OnLocaleChanged(ILocaleChangedEventArgs args);
    }
}