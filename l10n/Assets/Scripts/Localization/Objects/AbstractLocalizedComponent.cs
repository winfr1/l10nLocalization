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
        [Tooltip("The localized component attached to this gameobject.")]
        private TComponent m_component;
        protected TComponent Component => m_component ?? (m_component = GetComponent<TComponent>());
        
    }
}