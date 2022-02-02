using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace l10n.Localization.observables
{
    public class LocaleChangedEventArgs : ILocaleChangedEventArgs
    {
        #region Properties

        private readonly string m_newLocale;
        public string NewLocale => m_newLocale;

        #endregion

        public LocaleChangedEventArgs(string newLocale)
        {
            m_newLocale = newLocale;
        }
    }
}