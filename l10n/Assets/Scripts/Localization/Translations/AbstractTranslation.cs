using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace l10n.Localization.translations
{
    public abstract class AbstractTranslation
    {
        protected string key;

        protected string locale;

        protected object value;

        protected object owner;

    }
}