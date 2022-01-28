namespace l10n.Localization.objects.Exceptions
{
    /// <summary>
    /// Translation Exception.
    /// Thrown when no translation in the chosen locale is available. 
    /// </summary>
    [System.Serializable]
    public class TranslationNotFoundException : System.Exception
    {
        private static readonly string DefaultMessage = "Translation not found";
        public string Key { get; set; }
        public string Locale { get; set; }

        public TranslationNotFoundException() : base(DefaultMessage) { }

        public TranslationNotFoundException(string message) : base(message) { }

        public TranslationNotFoundException(string message, System.Exception innerException) : base(message, innerException) { }

        public TranslationNotFoundException(string key, string locale) : base(DefaultMessage)
        {
            Key = key;
            Locale = locale;
        }

        public TranslationNotFoundException(string key, string locale, System.Exception innerException) : base(DefaultMessage, innerException)
        {
            Key = key;
            Locale = locale;
        }

        protected TranslationNotFoundException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }
}