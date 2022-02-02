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
        public string CurrentLocale
        {
            get => m_currentLocale ?? (m_currentLocale = DefaultLanguage);
            private set
            {
                if (value != null && value != "") m_currentLocale = value;
                else m_currentLocale = DefaultLanguage;
            }
        }

        [SerializeField]
        private string m_defaultLanguage;
        public string DefaultLanguage => m_defaultLanguage ?? (m_defaultLanguage = "en-us");

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

        protected override void Awake()
        {
            base.Awake();
            LoadLocale();
        }

        public void SetLocale(string newLocale, bool forceReload = false)
        {
            if (newLocale != CurrentLocale || forceReload) {
                CurrentLocale = newLocale;
                LoadLocale();
            }
        }

        private void LoadLocale()
        {
            LoadLocaleAsync(CurrentLocale);
        }

        private async void LoadLocaleAsync(string locale)
        {
            State = LocalizationObservableState.LoadingLocale;

            await Provider.LoadTranslationsAsync(locale);

            m_localeChanged?.Invoke(new LocaleChangedEventArgs(m_currentLocale));

            State = LocalizationObservableState.LocaleLoaded;
        }
    }
}