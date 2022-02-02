using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace l10n.Localization.translations
{
    public class ImageTranslation : GenericTranslation<Image>
    {
        public ImageTranslation(string key, string locale, Image value, object owner) : base(key, locale, value, owner) { }
    }
}