using l10n.Localization.provider;
using System.Collections;
using UnityEngine;

namespace l10n.Localization.sources
{
    /// <summary>
    /// Serializes CSV file and adds translations to the <see cref="ILocalizationProvider"/>
    /// </summary>
    public class CSVDataHandler : AbstractDataHandler
    {
        public override void LoadTranslations(string locale)
        {
            l10nDependencyProvider.Instance.Provider.RegisterTranslation("test", "de", "Wert der Übersetzung", this);
        }
    }
}