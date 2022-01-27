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
        private List<AbstractTranslation> s_translations;
        public IList<AbstractTranslation> Translations => s_translations ?? throw new Exception();

        [SerializeField]
        private List<ILocalizationDataHandler> s_dataHandlers;
        public IList<ILocalizationDataHandler> DataHandlers => s_dataHandlers;

        public async Task LoadTranslationsAsync()
        {
            //TODO

        }

        public void register(ILocalizationDataHandler handler)
        {
            s_dataHandlers.Add(handler);
        }

        public void unregister(ILocalizationDataHandler handler)
        {
            s_dataHandlers.Remove(handler);
        }

        public bool RegisterTranslation(string key, string locale, object value, object owner)
        {
            throw new System.NotImplementedException();
        }

        public AbstractTranslation Translate(string key)
        {
            throw new System.NotImplementedException();
        }
    }
}