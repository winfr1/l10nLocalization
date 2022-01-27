﻿using l10n.common;
using l10n.Localization.provider;
using l10n.Localization.translations;
using System.Collections;
using UnityEngine;

namespace l10n.Localization
{
    /// <summary>
    /// Provides References to all the important classes in the framework.
    /// </summary>
    public sealed class l10nDependencyProvider : Singleton<l10nDependencyProvider>
    {
        /// <summary>
        /// protected constructor to prevent instantiation
        /// </summary>
        private l10nDependencyProvider() { }

        [SerializeField]
        private ILocalizationGenerator s_generator;
        public ILocalizationGenerator Generator => s_generator ?? (s_generator = new TranslationFactory());

        [SerializeField]
        private ILocalizationObservable s_observable;
        public ILocalizationObservable Observable => s_observable ?? (s_observable = l10nManager.Instance);

        [SerializeField]
        private ILocalizationProvider s_provider;
        public ILocalizationProvider Provider => s_provider ?? (s_provider = l10nManager.Instance);


        protected override void Awake()
        {
            base.Awake();            
        }

    }

}