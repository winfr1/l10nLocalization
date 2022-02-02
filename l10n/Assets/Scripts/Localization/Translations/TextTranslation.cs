using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace l10n.Localization.translations
{
    /// <summary>
    /// Translation with string values
    /// </summary>
    public class TextTranslation : GenericTranslation<string>
    {
        public TextTranslation(string key, string locale, string value, object owner) : base(key, locale, value, owner) { }
    }
}