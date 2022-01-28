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
        private Dictionary<string, AbstractTranslation> s_translations;
        public IReadOnlyDictionary<string, AbstractTranslation> Translations => s_translations ?? (s_translations = new Dictionary<string, AbstractTranslation>());

        [SerializeField]
        private List<ILocalizationDataHandler> s_dataHandlers;
        public IList<ILocalizationDataHandler> DataHandlers => s_dataHandlers ?? (s_dataHandlers = new List<ILocalizationDataHandler>());

        [SerializeField]
        private ILocalizationGenerator s_generator;
        public ILocalizationGenerator Generator => s_generator ?? (s_generator = new TranslationFactory());

        public Task LoadTranslationsAsync(string locale)
        {
            s_translations.Clear();

            foreach(var dataHandler in s_dataHandlers)
            {
                dataHandler.LoadTranslations(locale);
            }
            return Task.CompletedTask;
        }

        public void RegisterHandler(ILocalizationDataHandler handler)
        {
            DataHandlers.Add(handler);
        }

        public void UnregisterHandler(ILocalizationDataHandler handler)
        {
            DataHandlers.Remove(handler);
        }

        public bool RegisterTranslation(string key, string locale, object value, object owner)
        {
            try
            {
                s_translations.Add(key, Generator.GenerateTranslation(key, locale, value, owner));
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