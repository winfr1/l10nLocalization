using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace l10n.Localization.objects
{
    /// <summary>
    /// Implementation for localizing components or scripts attached to gameobjects
    /// </summary>
    public abstract class AbstractLocalizedComponent<TComponent> : AbstractLocalizedObject
    {
        [SerializeField]
        private TComponent s_component;

        protected TComponent Component => s_component ?? (s_component = gameObject.GetComponent<TComponent>());
    }
}