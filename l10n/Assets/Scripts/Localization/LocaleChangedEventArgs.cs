using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace l10n.Localization
{
    public class LocaleChangedEventArgs : ILocaleChangedEventArgs
    {
        private string s_newLocale;
        public string NewLocale => s_newLocale;
    }
}