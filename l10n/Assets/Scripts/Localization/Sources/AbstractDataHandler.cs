using l10n.Localization.observables;

namespace l10n.Localization.sources
{
    /// <summary>
    /// Base class for Data Sources.
    /// </summary>
    public abstract class AbstractDataHandler : ILocalizationDataHandler
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
        protected virtual void Awake()
        {
            l10nDependencyProvider.Instance.Provider.register(this);
        }

        protected virtual void OnDisable()
        {
            l10nDependencyProvider.Instance.Provider.unregister(this);
        }

        #endregion
    }
}