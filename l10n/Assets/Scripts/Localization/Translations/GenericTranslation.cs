using System.Collections;
using UnityEngine;

namespace l10n.Localization.translations
{
    /// <summary>
    /// Generic Translation class for all value types.
    /// </summary>
    public class GenericTranslation<T> : AbstractTranslation
    {
        protected T m_value;
        public T Value => m_value;

        public GenericTranslation(string key, string locale, T value, object owner) : base(key, locale, owner) 
        {
            m_value = value;
        }
    } 
}