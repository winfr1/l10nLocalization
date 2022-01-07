namespace l10n.Localization
{
    /// <summary>
    /// Abstraction for Arguments for the event <see cref="ILocalizationObservable.LocaleChanged"/>
    /// </summary>
    internal interface ILocaleChangedEventArgs
    {
         string NewLocale { get; }
    }
}