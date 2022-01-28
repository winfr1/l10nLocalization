using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace l10n.Localization.translations
{
    public abstract class AbstractTranslation
    {
        public string Key { get; }

        public string Locale { get; }

        public object Value { get; }

        public object Owner { get; }

    }
}