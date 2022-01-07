using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace l10n.Localization
{
    public class LocaleChangedEventArgs : ILocaleChangedEventArgs
    {
        #region Properties

        private string s_newLocale;
        public string NewLocale => s_newLocale;

        #endregion

        public LocaleChangedEventArgs(string newLocale)
        {
            s_newLocale = newLocale;
        }
    }
}