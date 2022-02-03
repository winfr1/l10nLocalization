using l10n.Localization.objects.Exceptions;
using l10n.Localization.observables;
using l10n.Localization.translations;
using UnityEngine;
using UnityEngine.UI;


namespace l10n.Localization.objects
{
    /// <summary>
    /// Implementation for localizing components or scripts attached to gameobjects
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Text))]
    [AddComponentMenu(l10nDependencyProvider.MenuPrefix + "Localized Text Component")]
    public class LocalizedTextComponent : AbstractLocalizedComponent<Text>
    {
        public override void UpdateValue()
        {
            try
            {
                Debug.Log("Trying to get Translation for key " + Key);
                var translation = Provider.Translate(Key) as TextTranslation;
                Component.text = translation.Value;
            }
            catch (TranslationNotFoundException e)
            {
                //TODO Fallback Value 
                Debug.LogException(e);
                Component.text = "[NOT FOUND]";
                return;
            }
        }
    }
}