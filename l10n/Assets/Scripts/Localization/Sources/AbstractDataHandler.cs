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
        protected string TranslationLanguage
        {
            get => m_translationLanguage;
            set
            {
                m_translationLanguage = value;
            }
        }

        #region ILocalizationDataHandler
        public abstract Task LoadTranslations();

        public abstract void LoadLocaleName();
        #endregion

        #region Lifecycle
        protected virtual void Awake()
        {
            LoadLocaleName();
        }

        protected virtual void OnEnable()
        {
            if (Application.isPlaying) Provider.RegisterHandler(TranslationLanguage, this);
        }

        protected virtual void OnDisable()
        {
            if (Application.isPlaying) Provider.UnregisterHandler(TranslationLanguage, this);
        }
        #endregion
    }
}