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
    public class LocalizationProvider : ILocalizationProvider
    {
        [SerializeField]
        private Dictionary<string, AbstractTranslation> m_translations;
        public IDictionary<string, AbstractTranslation> Translations => m_translations ?? (m_translations = new Dictionary<string, AbstractTranslation>());

        [SerializeField]
        private Dictionary<string, ILocalizationDataHandler> m_dataHandlers;
        public IDictionary<string, ILocalizationDataHandler> DataHandlers => m_dataHandlers ?? (m_dataHandlers = new Dictionary<string, ILocalizationDataHandler>());

        [SerializeField]
        private ILocalizationGenerator m_generator;
        public ILocalizationGenerator Generator => m_generator ?? (m_generator = new TranslationFactory());

        public Task LoadTranslationsAsync(string locale)
        {
            Translations.Clear();
            ILocalizationDataHandler handler;
            if(DataHandlers.TryGetValue(locale, out handler))
            {
                handler.LoadTranslations();
            }
            return Task.CompletedTask;
        }

        public void RegisterHandler(string language, ILocalizationDataHandler handler)
        {
            DataHandlers.Add(language, handler);
            l10nDependencyProvider.Observable.AvailableLanguages.Add(language);
        }

        public void UnregisterHandler(string language, ILocalizationDataHandler handler)
        {
            DataHandlers.Remove(language);
            l10nDependencyProvider.Observable.AvailableLanguages.Remove(language);
        }

        public bool RegisterTranslation(string key, string locale, object value, object owner)
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
            if (Translations.TryGetValue(key, out translation))
            {
                return translation;
            } else
            {
                throw new TranslationNotFoundException(key);
            }
        }
    }
}