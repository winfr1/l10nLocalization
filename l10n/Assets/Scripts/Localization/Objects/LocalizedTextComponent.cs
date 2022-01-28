using l10n.Localization.objects.Exceptions;
using l10n.Localization.observables;
using UnityEngine;
using UnityEngine.UI;


namespace l10n.Localization.objects
{
    /// <summary>
    /// Implementation for localizing components or scripts attached to gameobjects
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class LocalizedTextComponent : AbstractLocalizedComponent<Text>
    {
        public override void UpdateValue()
        {
            try
            {
                var translation = Provider.Translate(key);
                Component.text = (string)translation.Value;
            }
            catch (TranslationNotFoundException e)
            {
                //TODO Fallback Value 
                Observable.Logger.Log(e.Message, LogType.Exception);
                return;
            }
        }
    }
}