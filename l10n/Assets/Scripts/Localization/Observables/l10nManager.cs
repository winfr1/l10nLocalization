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
    [ExecuteInEditMode]
    [DisallowMultipleComponent]
    [AddComponentMenu(l10nDependencyProvider.MenuPrefix + "Localization Manager")]
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
            get
            {
                if (string.IsNullOrEmpty(m_currentLocale)) return m_currentLocale = DefaultLanguage;
                return m_currentLocale;
            }
            private set
            {
                if (!string.IsNullOrEmpty(value)) m_currentLocale = value;
                else m_currentLocale = DefaultLanguage;
            }
        }

        [SerializeField]
        private string m_defaultLanguage;
        public string DefaultLanguage
        {
            get
            {
                if (string.IsNullOrEmpty(m_defaultLanguage) && AvailableLanguages.Count > 0)
                {
                    return m_defaultLanguage = AvailableLanguages[0];
                }
                else return m_defaultLanguage = "en-us";
            }
        }

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

        private LocalizationObservableState m_state;
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

        [SerializeField]
        private List<string> m_availableLanguages;
        public IList<string> AvailableLanguages => m_availableLanguages ?? (m_availableLanguages = new List<string>());

        public void RegisterLanguage(string locale)
        {
            m_availableLanguages.Add(locale);
        }

        public void RemoveLanguage(string locale)
        {
            m_availableLanguages.Remove(locale);
        }

        #endregion

        /// <summary>
        /// Private Constructor to prevent creation of other Instances.
        /// </summary>
        private l10nManager() { }

        protected override void Awake()
        {
            base.Awake();
            m_state = LocalizationObservableState.Initializing;
            //LoadLocale();
        }

        protected void OnEnable()
        {
            var currentLocale = CurrentLocale;
            Debug.Log("Enabled Manager with Locale " + currentLocale);
            LoadLocale();
        }

        protected override void OnDisable()
        {
            m_currentLocale = null;
            m_defaultLanguage = null;
            m_availableLanguages.Clear();
            m_localeChanged = null;
            m_provider = null;
        }

        public void SetLocale(string newLocale, bool forceReload = false)
        {
            if (newLocale != CurrentLocale || forceReload) {
                CurrentLocale = newLocale;
                LoadLocale();
            }
        }

        [ContextMenu("Load Translations for Current Language")]
        private void LoadLocale()
        {
            LoadLocaleAsync(CurrentLocale);
        }

        private async void LoadLocaleAsync(string locale)
        {
            State = LocalizationObservableState.LoadingLocale;

            await Provider.LoadTranslationsAsync();

            m_localeChanged?.Invoke(new LocaleChangedEventArgs(m_currentLocale));
            Debug.Log("Invoked Locale Changed");


            State = LocalizationObservableState.LocaleLoaded;
        }
    }
}