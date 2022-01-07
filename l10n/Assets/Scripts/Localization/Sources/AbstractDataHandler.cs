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

        #region ILocalizationDataHandler
        public void ReloadTranslations(string locale)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Lifecycle
        protected override void Awake()
        {
            base.Awake();
        }

        #endregion
    }
}