using l10n.Localization.observables;
using l10n.Localization.provider;
using System.Threading.Tasks;
using UnityEngine;

namespace l10n.Localization.sources
{
    /// <summary>
    /// Base class for Data Sources.
    /// </summary>
    public abstract class AbstractDataHandler : MonoBehaviour, ILocalizationDataHandler
    {
        private ILocalizationProvider m_provider;
        protected ILocalizationProvider Provider => m_provider ?? (m_provider = l10nDependencyProvider.Provider);

        [SerializeField]
        private string m_translationLanguage;
        public string TranslationLanguage
        {
            get => m_translationLanguage;
            set { m_translationLanguage = value; }
        }

        #region ILocalizationDataHandler
        public abstract Task LoadTranslations();

        public abstract void LoadLocaleName();
        #endregion

        #region Lifecycle
        protected virtual void Awake()
        {
            LoadLocaleName();
            if (Application.isPlaying) Provider.RegisterHandler(this);
        }

        protected virtual void OnDisable()
        {
            if (Application.isPlaying) Provider.UnregisterHandler(this);
        }
        #endregion
    }
}