using l10n.common;
using l10n.Localization.sources;
using l10n.Localization.translations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace l10n.Localization.observables
{
    /// <summary>
    /// Central Manager for localization settings of the application. 
    /// Does all localization processing and generation of translations during runtime. 
    /// </summary>

    public class l10nManager : Singleton<l10nManager>, ILocalizationObservable
    {

        #region Properties
        [SerializeField]
        private ILocalizationLogger s_logger;
        public ILocalizationLogger Logger => s_logger ?? (s_logger = new LocalizationLogger());

        [SerializeField]
        private string s_currentLocale;
        public string CurrentLocale
        {
            get { return s_currentLocale; }
            set
            {
                Logger.Log(string.Format("Localization Changed from {0} to {1}", s_currentLocale, value), LogType.Log);
                s_currentLocale = value;
                await l10nDependencyProvider.Instance.Provider.LoadTranslationsAsync();
                LocaleChangedEventArgs args = new LocaleChangedEventArgs(s_currentLocale);
                s_localeChanged.Invoke(this, args);
            }
        }
        private event EventHandler<ILocaleChangedEventArgs> s_localeChanged;

        public event EventHandler<ILocaleChangedEventArgs> LocaleChanged
        {
            add
            {
                s_localeChanged += value;
            }
            remove
            {
                s_localeChanged -= value;
            }
        }

        [SerializeField]
        private ILocalizationDataHandler s_dataHandler;

        #endregion

        /// <summary>
        /// Private Constructor to prevent creation of other Instances.
        /// </summary>
        private l10nManager() { }

    }
}