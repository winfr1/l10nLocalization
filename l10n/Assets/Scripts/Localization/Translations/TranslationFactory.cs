using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace l10n.Localization.translations
{
    public class TranslationFactory : ILocalizationGenerator
    {
        public AbstractTranslation GenerateTranslation<T>(string key, string locale, T value, object owner)
        {
            if (value.GetType() == typeof(string))
            {
                return CreateTextTranslation(key, locale, value as string, owner);
            }
            else
            {
                return CreateGenericTranslation(key, locale, value, owner);
            }
        }


        private GenericTranslation<T> CreateGenericTranslation<T>(string key, string locale, T value, object owner)
        {
            return new GenericTranslation<T>(key, locale, value, owner);
        }

        private TextTranslation CreateTextTranslation(string key, string locale, string value, object owner)
        {
            return new TextTranslation(key, locale, value, owner);
        }
    }
}