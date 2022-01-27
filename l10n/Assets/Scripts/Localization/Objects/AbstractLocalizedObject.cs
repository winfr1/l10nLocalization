using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace l10n.Localization.objects
{
    /// <summary>
    /// Implementation to localize GameObjects
    /// </summary>
    public abstract class AbstractLocalizedObject : AbstractLocalizationObserver, ILocalizable
    {
        public abstract void UpdateValue();
    }
}