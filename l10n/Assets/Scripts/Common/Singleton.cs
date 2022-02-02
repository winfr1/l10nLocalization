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
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        #region Properties

        private static T m_instance;
        private static bool m_isAvailable = true;

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
                    // Used when the application is quitting, but the instance is still called
                    if (m_instance == null && m_isAvailable)
                    {
                        m_instance = FindObjectOfType<T>();

                        if (m_instance == null)
                        {
                            GameObject go = new GameObject(typeof(T).Name);
                            m_instance = go.AddComponent<T>();
                            DontDestroyOnLoad(go);
                        }
                    }
                    return m_instance;
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
            m_isAvailable = false;
            m_instance = null;
        }

        /// <summary>
        /// This method initializes a singleton instance and prevents the creation of a second Singleton.
        /// Called during <see cref="Awake"/> Lifecycle. 
        /// </summary>
        private void initOrDestroyInstance()
        {
            if (m_instance == null)
            {
                m_instance = this as T;
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