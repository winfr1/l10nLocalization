using l10n.Localization.provider;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace l10n.Localization.sources
{
    /// <summary>
    /// Base class for Data Sources.
    /// </summary>
    public abstract class AbstractDataHandler : AbstractLocalizationObserver, ILocalizationDataHandler
    {
        #region AbstractLocalizationObserver

        protected override void OnLocaleChanged(object sender, ILocaleChangedEventArgs args)
        {
            LoadTranslations(args.NewLocale);
        }

        #endregion

        #region ILocalizationDataHandler
        public abstract void LoadTranslations(string locale);
        #endregion

        #region Lifecycle
        protected override void Awake()
        {
            base.Awake();
        }

        #endregion
    }
}