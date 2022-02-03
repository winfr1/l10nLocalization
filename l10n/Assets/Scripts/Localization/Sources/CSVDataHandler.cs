using l10n.Localization.provider;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;

namespace l10n.Localization.sources
{
    /// <summary>
    /// Serializes CSV file and registers translations to the <see cref="ILocalizationProvider"/>
    /// </summary>
    [AddComponentMenu(l10nDependencyProvider.MenuPrefix + "CSV Data Handler")]
    [ExecuteInEditMode]
    public class CSVDataHandler : AbstractDataHandler
    {
        /// <summary>
        /// Character for the separation columns.
        /// </summary>
        [SerializeField]
        private char m_separatorType = ',';
        public char SeparatorType => m_separatorType;

        /// <summary>
        /// Reference to the CSV file from Assets.
        /// </summary>
        [SerializeField]
        private TextAsset m_dataSource;
        public TextAsset DataSource => m_dataSource;

        public override void LoadLocaleName()
        {
            TranslationLanguage = DataSource.name;
        }

        public override Task LoadTranslations()
        {
            string CSVFile = m_dataSource.text;
            string[] lines = GetDataLines(CSVFile);

            // Iterate over all lines
            for (var i = 0; i < lines.Length; i++)
            {
                string[] data = GetData(lines[i]);

                string key = data[0];
                string value = data[1];
                if (key == "" || value == "") continue;

                Provider.RegisterTranslation(key, TranslationLanguage, value, this);
            }
            
            return Task.CompletedTask;
        }

        /// <summary>
        /// Separates a csv string by lines, removes the first line with column names
        /// </summary>
        /// <param name="csv">text to be separated</param>
        /// <returns>Data Lines of the CSV</returns>
        private string[] GetDataLines(string csv)
        {
            String[] lines = csv.Split( new[]{ Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            return lines.Skip(1).ToArray();
        }

        private string[] GetData(string line)
        {
            return line.Split(SeparatorType);
        }

        [ContextMenu("Reload Data Source")]
        public void LoadDataSource()
        {
            LoadTranslations();
        }
    }
}