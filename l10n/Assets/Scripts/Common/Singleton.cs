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
        #region Properties

        private static T s_instance;
        private static bool s_isAvailable;

        // Lock object for thread safety
        private static readonly object padlock = new object();

        /// <summary>
        /// Returns the Instance of the singleton object.
        /// </summary>
        public static T Instance
        {
            get
            {
                //provides thread safety
                lock (padlock)
                {
                    if (!s_isAvailable)
                    {
                        return null;
                    }
                    if (s_instance == null)
                    {
                        s_instance = FindObjectOfType<T>();

                        if (s_instance == null)
                        {
                            GameObject go = new GameObject(typeof(T).Name);
                            s_instance = go.AddComponent<T>();
                            DontDestroyOnLoad(go);
                        }
                    }
                    return s_instance;
                }
            }
        }

        #endregion

        #region Lifecycle
        protected virtual void Awake()
        {
            initOrDestroyInstance();
        }

        protected virtual void OnDisable()
        {
            s_instance = null;
            s_isAvailable = false;
        }

        /// <summary>
        /// This method initializes a singleton instance and prevents the creation of a second Singleton.
        /// Called during <see cref="Awake"/> Lifecycle. 
        /// </summary>
        private void initOrDestroyInstance()
        {
            if (s_instance == null)
            {
                s_instance = this as T;
                s_isAvailable = true;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion
    }
}