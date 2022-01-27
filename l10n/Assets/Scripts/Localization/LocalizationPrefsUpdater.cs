using l10n.Localization.observables;
using UnityEngine;

namespace l10n.Localization
{
    /// <summary>
    /// Synchronises the PlayerPrefs with the <see cref="ILocalizationObservable.CurrentLocale"/>
    /// </summary>
    public sealed class LocalizationPrefsUpdater : AbstractLocalizationObserver
    {
        private readonly string prefsKey = "l10n.CurrentLocale";

        protected override void OnLocaleChanged(object sender, ILocaleChangedEventArgs args)
        {
            PlayerPrefs.SetString(prefsKey, args.NewLocale);
        }

        protected override void Awake()
        {
            base.Awake();
            l10nDependencyProvider.Instance.Observable.CurrentLocale = PlayerPrefs.GetString(prefsKey);
        }
    }
}