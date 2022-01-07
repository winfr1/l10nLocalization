using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace l10n.common
{
    /// <summary>
    /// Implementation of a Singleton Pattern for <see cref="MonoBehaviour"/>.
    /// Get the object via <see cref="Instance"/>.
    /// </summary>
    /// <typeparam name="T">MonoBehaviour component that should be generated as Singleton.</typeparam>
    public abstract class Singleton<T> : MonoBehaviour where T: MonoBehaviour
    {
        private static T s_instance;

        /// <summary>
        /// Returns the Instance of the singleton object.
        /// </summary>
        public static T Instance
        {
            get
            {
                return s_instance;
            }
        }
    }
}