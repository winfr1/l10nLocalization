using l10n.Localization.provider;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace l10n.Localization.sources
{
    /// <summary>
    /// Serializes CSV file and adds translations to the <see cref="ILocalizationProvider"/>
    /// </summary>
    public class CSVDataHandler : AbstractDataHandler
    {
        public override Task LoadTranslations(string locale)
        {
            Provider.RegisterTranslation("test", "de", "Wert der Übersetzung", this);

            return Task.CompletedTask;
        }
    }
}