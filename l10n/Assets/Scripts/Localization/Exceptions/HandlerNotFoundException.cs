namespace l10n.Localization.objects.Exceptions
{
    /// <summary>
    /// Translation Exception.
    /// Thrown when no translation in the chosen locale is available. 
    /// </summary>
    [System.Serializable]
    public class HandlerNotFoundException : System.Exception
    {
        private static readonly string DefaultMessage = "Handler not found";
        public string Locale { get; set; }

        public HandlerNotFoundException() : base(DefaultMessage) { }

        public HandlerNotFoundException(string locale) : base(DefaultMessage)
        {
            Locale = locale;
        }

        public HandlerNotFoundException(string locale, System.Exception innerException) : base(DefaultMessage, innerException)
        {
            Locale = locale;
        }

        protected HandlerNotFoundException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }
}