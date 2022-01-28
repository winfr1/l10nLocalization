using l10n.Localization.observables;
using l10n.Localization.provider;
using System.Threading.Tasks;

namespace l10n.Localization.sources
{
    /// <summary>
    /// Base class for Data Sources.
    /// </summary>
    public abstract class AbstractDataHandler : ILocalizationDataHandler
    {
        private ILocalizationProvider s_provider;
        protected ILocalizationProvider Provider => s_provider ?? (s_provider = l10nDependencyProvider.Instance.Provider);

        #region ILocalizationDataHandler
        public abstract Task LoadTranslations(string locale);
        #endregion

        #region Lifecycle
        protected virtual void Awake()
        {
            Provider.RegisterHandler(this);
        }

        protected virtual void OnDisable()
        {
            Provider.UnregisterHandler(this);
        }

        #endregion
    }
}