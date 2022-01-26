using l10n.Localization.provider;
using System;
using UnityEngine;

namespace l10n.Localization
{

    public abstract class AbstractLocalizationObserver : MonoBehaviour
    {

        #region properties

        #endregion

        #region Lifecycle
        protected virtual void Awake()
        {
            l10nManager.Instance.LocaleChanged += OnLocaleChanged;
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