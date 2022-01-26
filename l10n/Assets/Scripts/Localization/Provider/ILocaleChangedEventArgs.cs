namespace l10n.Localization.provider
{
    /// <summary>
    /// Abstraction for Arguments for the event <see cref="ILocalizationObservable.LocaleChanged"/>
    /// </summary>
    public interface ILocaleChangedEventArgs
    {
        /// <summary>
        /// New Language that was selected.
        /// </summary>
         string NewLocale { get; }
    }
}