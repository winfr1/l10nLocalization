using l10n.common;
using l10n.Localization.sources;
using l10n.Localization.translations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace l10n.Localization.provider
{
    /// <summary>
    /// Central Manager for localization settings of the application. 
    /// Does all localization processing and generation of translations during runtime. 
    /// </summary>

    public class l10nManager : Singleton<l10nManager>, ILocalizationObservable, ILocalizationProvider
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
                LocaleChangedEventArgs args = new LocaleChangedEventArgs(s_currentLocale);
                LocaleChanged.Invoke(this, args);
            }
        }

        public event EventHandler<ILocaleChangedEventArgs> LocaleChanged;

        [SerializeField]
        private ILocalizationDataHandler s_dataHandler;

        [SerializeField]
        private List<AbstractTranslation> s_translations;
        public IList<AbstractTranslation> Translations => s_translations ?? throw new Exception();

        #endregion

        /// <summary>
        /// Private Constructor to prevent creation of other Instances.
        /// </summary>
        private l10nManager() { }


        #region ILocalizationProvider

        public AbstractTranslation Translate(string key)
        {
            throw new NotImplementedException();
        }

        public bool RegisterTranslation(string key, string locale, object value, object owner)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}