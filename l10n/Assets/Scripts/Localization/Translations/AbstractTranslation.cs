using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace l10n.Localization.translations
{
    /// <summary>
    /// Parent Class for translations
    /// </summary>
    public abstract class AbstractTranslation
    {
        protected string m_key;
        public string Key => m_key;

        protected string m_locale;
        public string Locale => m_locale;

        protected object m_owner;
        public object Owner => m_owner;

        public AbstractTranslation(string key, string locale, object owner) {
            m_key = key;
            m_locale = locale;
            m_owner = owner;
        }
    }
}