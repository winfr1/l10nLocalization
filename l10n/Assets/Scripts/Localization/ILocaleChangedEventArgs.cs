namespace l10n.Localization
{
    /// <summary>
    /// Abstraction for Arguments for the event <see cref="ILocalizationObservable.LocaleChanged"/>
    /// </summary>
    public interface ILocaleChangedEventArgs
    {
         string NewLocale { get; }
    }
}