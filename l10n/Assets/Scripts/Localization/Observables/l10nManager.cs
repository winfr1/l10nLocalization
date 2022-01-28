using l10n.common;
using l10n.Localization.provider;
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
        public string CurrentLocale => s_currentLocale;

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

        private LocalizationObservableState s_state = LocalizationObservableState.Initializing;
        public LocalizationObservableState State
        {
            get { return s_state; }
            set
            {
                s_state = value;
                StateChanged.Invoke(s_state);
            }
        }

        public event Action<LocalizationObservableState> StateChanged;

        [SerializeField]
        private ILocalizationProvider s_provider;
        public ILocalizationProvider Provider => s_provider ?? (s_provider = l10nDependencyProvider.Instance.Provider);

        private List<string> s_availableLangauges;
        public IList<string> AvailableLanguages => s_availableLangauges ?? (s_availableLangauges = new List<string>());

        #endregion

        /// <summary>
        /// Private Constructor to prevent creation of other Instances.
        /// </summary>
        private l10nManager() { }

        public void SetLocale(string newLocale)
        {
            s_currentLocale = newLocale;
            
            State = LocalizationObservableState.LocaleChanged;

            Logger.Log(string.Format("New Locale {0} was set, loading translations", newLocale), LogType.Log);

            LoadLocaleAsync(newLocale);
        }

        private async void LoadLocaleAsync(string locale)
        {
            State = LocalizationObservableState.LoadingLocale;

            await Provider.LoadTranslationsAsync(locale);

            s_localeChanged.Invoke(this, new LocaleChangedEventArgs(s_currentLocale));

            State = LocalizationObservableState.LocaleLoaded;
        }
    }
}