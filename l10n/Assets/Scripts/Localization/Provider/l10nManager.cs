using l10n.common;
using l10n.Localization.translations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace l10n.Localization.provider
{
    /// <summary>
    /// Central Manager for localization settings of the application. 
    /// Does all localization processing and generation of translations during runtime. 
    /// </summary>
    public class l10nManager : AbstractLocalizationManager
    {
        #region Contructor
        /// <summary>
        /// Private Constructor to prevent creation of other Instances.
        /// </summary>
        private l10nManager() { }
        #endregion

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}