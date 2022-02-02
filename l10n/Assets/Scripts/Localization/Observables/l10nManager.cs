using l10n.common;
using l10n.Localization.objects.Exceptions;
using l10n.Localization.provider;
using l10n.Localization.sources;
using l10n.Localization.translations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace l10n.Localization.observables
{
    /// <summary>
    /// Central Manager for localization settings of the application. 
    /// Starts generation of translations during runtime. 
    /// </summary>
    public class l10nManager : Singleton<l10nManager>, ILocalizationObservable
    {
        #region Properties
        [SerializeField]
        private ILocalizationLogger m_logger;
        public ILocalizationLogger Logger => m_logger ?? (m_logger = new LocalizationLogger());

        [SerializeField]
        private string m_currentLocale;
        public string CurrentLocale => m_currentLocale ?? (m_currentLocale = "en-us");

        private event Action<ILocaleChangedEventArgs> m_localeChanged;

        public event Action<ILocaleChangedEventArgs> LocaleChanged
        {
            add
            {
                Debug.Log("New Component registered for LocaleChanged Event");
                m_localeChanged += value;
            }
            remove
            {
                m_localeChanged -= value;
            }
        }

        private LocalizationObservableState m_state = LocalizationObservableState.Initializing;
        public LocalizationObservableState State
        {
            get { return m_state; }
            set
            {
                m_state = value;
                StateChanged?.Invoke(m_state);
            }
        }

        public event Action<LocalizationObservableState> StateChanged;

        [SerializeField]
        private ILocalizationProvider m_provider;
        public ILocalizationProvider Provider => m_provider ?? (m_provider = l10nDependencyProvider.Provider);

        private List<string> m_availableLangauges;
        public IList<string> AvailableLanguages => m_availableLangauges ?? (m_availableLangauges = new List<string>());

        #endregion

        /// <summary>
        /// Private Constructor to prevent creation of other Instances.
        /// </summary>
        private l10nManager() { }

        public void SetLocale(string newLocale)
        {
            if (CurrentLocale != newLocale && (newLocale != null && newLocale != ""))
            {
                Debug.Log("New Locale was set "+ newLocale);
                m_currentLocale = newLocale;

                State = LocalizationObservableState.LoadingLocale;

                Logger.Log(string.Format("New Locale {0} was set, loading translations", newLocale), LogType.Log);

                LoadLocaleAsync(newLocale);
            }
        }

        private async void LoadLocaleAsync(string locale)
        {
            Debug.Log("Loading Translations Async");
            await Provider.LoadTranslationsAsync(locale);

            m_localeChanged?.Invoke(new LocaleChangedEventArgs(m_currentLocale));

            State = LocalizationObservableState.LocaleLoaded;
        }
    }
}