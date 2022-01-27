using l10n.common;
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

        private ILocalizationLogger s_logger;

        private string s_currentLocale;

        private List<AbstractTranslation> s_translations;

        #endregion

        #region Contructor
        /// <summary>
        /// Private Constructor to prevent creation of other Instances.
        /// </summary>
        private l10nManager() { }


        #region ILocalizationObservable
        
        public ILocalizationLogger Logger => s_logger;

        public string CurrentLocale
        {
            get { return s_currentLocale; }
            set
            {
                s_currentLocale = value;
                LocaleChangedEventArgs args = new LocaleChangedEventArgs(s_currentLocale);
                LocaleChanged.Invoke(this, args);
            }
        }

        public event EventHandler<ILocaleChangedEventArgs> LocaleChanged;

        #endregion

        #region ILocalizationProvider

        public IList<AbstractTranslation> Translations => s_translations;

        public AbstractTranslation Translate(string key)
        {
            throw new NotImplementedException();
        }
        #endregion

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}