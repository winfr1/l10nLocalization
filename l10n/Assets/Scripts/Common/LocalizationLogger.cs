using System.Collections;
using UnityEngine;

namespace l10n.common
{
    public class LocalizationLogger : ILocalizationLogger
    {
        public void Log(string message, LogType type)
        {
            switch(type)
            {
                case LogType.Error:
                    Debug.LogError(message);
                    break;
                case LogType.Warning:
                    Debug.LogWarning(message);
                    break;
                default:
                    Debug.Log(message);
                    break;
            }
        }
    }
}