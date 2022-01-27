using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace l10n.Localization.translations
{
    public class TranslationFactory : ILocalizationGenerator
    {
        public AbstractTranslation GenerateTranslation(string key, string locale, object value, object owner)
        {
            throw new System.NotImplementedException();
        }
    }
}