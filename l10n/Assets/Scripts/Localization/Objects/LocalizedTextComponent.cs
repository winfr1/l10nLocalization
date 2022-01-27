using l10n.Localization.provider;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace l10n.Localization.objects
{
    /// <summary>
    /// Implementation for localizing components or scripts attached to gameobjects
    /// </summary>
    public class LocalizedTextComponent : AbstractLocalizedComponent
    {
        protected override void OnLocaleChanged(object sender, ILocaleChangedEventArgs args)
        {
            throw new System.NotImplementedException();
        }
    }
}