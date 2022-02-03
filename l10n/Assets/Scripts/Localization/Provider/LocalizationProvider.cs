using l10n.common;
using l10n.Localization.objects.Exceptions;
using l10n.Localization.sources;
using l10n.Localization.translations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace l10n.Localization.provider
{
    /// <summary>
    /// Basic Implementaation for <see cref="ILocalizationProvider"/>
    /// Handles the generation of translations from data sources.
    /// </summary>
    [ExecuteInEditMode]
    public class LocalizationProvider : Singleton<LocalizationProvider>, ILocalizationProvider
    {
        [NonSerialized]
        private Dictionary<string, AbstractTranslation> m_translations;
        public IDictionary<string, AbstractTranslation> Translations => m_translations ?? (m_translations = new Dictionary<string, AbstractTranslation>());

        [NonSerialized]
        private Dictionary<string, ILocalizationDataHandler> m_dataHandlers;
        public IDictionary<string, ILocalizationDataHandler> DataHandlers => m_dataHandlers ?? (m_dataHandlers = new Dictionary<string, ILocalizationDataHandler>());

        public string CurrentLocale => l10nDependencyProvider.Observable.CurrentLocale;

        [SerializeField]
        private ILocalizationGenerator m_generator;
        public ILocalizationGenerator Generator => m_generator ?? (m_generator = new TranslationFactory());

        private LocalizationProviderState m_state;

        public LocalizationProviderState State => m_state;

        public Task LoadTranslationsAsync()
        {
            m_state = LocalizationProviderState.TranslationsLoading;
            Translations.Clear();
            ILocalizationDataHandler handler;
            Debug.Log("Locale "+CurrentLocale+ " Handler " + DataHandlers.Count);
            if (DataHandlers.TryGetValue(CurrentLocale, out handler))
            {
                handler.LoadTranslations();
            }
            else
            {
                throw new HandlerNotFoundException(CurrentLocale);
            }
            m_state = LocalizationProviderState.TranslationsLoaded;
            return Task.CompletedTask;
        }

        public void RegisterHandler(ILocalizationDataHandler handler)
        {
            Debug.Log("Registered Handler for locale "+handler.TranslationLanguage);
            if (!DataHandlers.ContainsKey(handler.TranslationLanguage))
            {
                DataHandlers.Add(handler.TranslationLanguage, handler);
            }
            else
            {
                DataHandlers[handler.TranslationLanguage] = handler;
            }
            l10nDependencyProvider.Observable.RegisterLanguage(handler.TranslationLanguage);
        }

        public void UnregisterHandler(ILocalizationDataHandler handler)
        {
            DataHandlers.Remove(handler.TranslationLanguage);
            l10nDependencyProvider.Observable.RemoveLanguage(handler.TranslationLanguage);
        }

        public bool RegisterTranslation<T>(string key, string locale, T value, object owner)
        {
            try
            {
                var translation = Generator.GenerateTranslation(key, locale, value, owner);
                m_translations.Add(key, translation);
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public AbstractTranslation Translate(string key)
        {
            AbstractTranslation translation;
            Debug.Log("Number of Translatzions "+Translations.Count);
            if (Translations.TryGetValue(key, out translation))
            {
                return translation;
            }
            else
            {
                throw new TranslationNotFoundException(CurrentLocale);
            }
        }
    }
}