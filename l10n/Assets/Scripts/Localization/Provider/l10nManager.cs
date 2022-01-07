using l10n.common;
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
    public class l10nManager : Singleton<l10nManager>, ILocalizationObservable, ILocalizationProvider<string>
    {
        #region Properties
        private string s_currentLocale;

        #endregion

        #region Contructor
        /// <summary>
        /// Private Constructor to prevent creation of other Instances.
        /// </summary>
        private l10nManager() { }
        #endregion

        #region ILocalizationObservable
        public string CurrentLocale {
            get { return s_currentLocale; }
            set { 
                s_currentLocale = value;
                LocaleChangedEventArgs args = new LocaleChangedEventArgs(s_currentLocale);
                LocaleChanged.Invoke(this, args);
            }
        }

        public event EventHandler<ILocaleChangedEventArgs> LocaleChanged;

        #endregion

        #region ILocalizationProvider
        public string translate(string key)
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