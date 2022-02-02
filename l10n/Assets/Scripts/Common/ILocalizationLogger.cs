using System;
using UnityEditor;
using UnityEngine;

namespace l10n.common
{
    /// <summary>
    /// Logger implementation
    /// </summary>
    public interface ILocalizationLogger
    {
        /// <summary>
        /// Logs a message to the console with the given type.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        /// <param name="type">Severity of the log</param>
        void Log(string message, LogType type);
    }
}