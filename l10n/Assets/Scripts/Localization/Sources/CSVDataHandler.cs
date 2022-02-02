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
    [ExecuteAlways]
    [AddComponentMenu(l10nDependencyProvider.MenuPrefix + "CSV Data Handler")]
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

        /// <summary>
        /// e
        /// </summary>
        [SerializeField]
        private Dictionary<string, string> m_entries;
        public Dictionary<string, string> Entries => m_entries ?? (m_entries = new Dictionary<string, string>());

        public override Task LoadTranslations()
        {
            var text = DataSource.text;
            var matches = Regex.Matches(text, "\"[\\s\\S]+?\"");

            // Separates the CSV file by lines
            var lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            TranslationLanguage = lines[0].Split(SeparatorType).Select(i => i.Trim()).ToList()[1];

            if (Application.isPlaying) { 
                // the first line contains the headlines
                for (var i = 1; i < lines.Length; i++)
                {
                    var columns = lines[i].Split(SeparatorType)
                        .Select(j => j.Trim())
                        .ToList();

                    var key = columns[0];
                    var value = columns[1];
                    if (key == "" || value == "") continue;

                    Provider.RegisterTranslation(key, TranslationLanguage, value, this);
                }
            }
            return Task.CompletedTask;
        }

        [ContextMenu("Reload Data Source")]
        public void LoadDataSource()
        {
            LoadTranslations();
        }
    }
}