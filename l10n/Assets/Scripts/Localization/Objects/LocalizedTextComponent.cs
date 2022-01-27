using l10n.Localization.observables;
namespace l10n.Localization.objects
{
    /// <summary>
    /// Implementation for localizing components or scripts attached to gameobjects
    /// </summary>
    public class LocalizedTextComponent : AbstractLocalizedComponent
    {
        public override void UpdateValue()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnLocaleChanged(object sender, ILocaleChangedEventArgs args)
        {
            UpdateValue();
        }
    }
}