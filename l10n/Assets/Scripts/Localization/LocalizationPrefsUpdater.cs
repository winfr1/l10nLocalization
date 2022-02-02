using l10n.Localization.observables;
using UnityEngine;

namespace l10n.Localization
{
    /// <summary>
    /// Synchronises the PlayerPrefs with the <see cref="ILocalizationObservable.CurrentLocale"/>
    /// </summary>
    [AddComponentMenu(l10nDependencyProvider.MenuPrefix + "Localization Player Prefs Updater")]
    [DisallowMultipleComponent]
    public sealed class LocalizationPrefsUpdater : AbstractLocalizationObserver
    {
        private readonly string prefsKey = "l10n.CurrentLocale";

        protected override void OnLocaleChanged(ILocaleChangedEventArgs args)
        {
            PlayerPrefs.SetString(prefsKey, args.NewLocale);
        }

        void Awake()
        {
            l10nDependencyProvider.Observable.SetLocale(PlayerPrefs.GetString(prefsKey));
        }
    }
}