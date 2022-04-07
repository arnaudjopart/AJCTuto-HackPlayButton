using System;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Editor
{
   [InitializeOnLoad]
   public class CustomPlayButtonBehaviour
   {
      static CustomPlayButtonBehaviour()
      {
         EditorApplication.playModeStateChanged += OnPlayModeChange;
      }

      private static void OnPlayModeChange(PlayModeStateChange _obj)
      {
         switch (_obj)
         {
            case PlayModeStateChange.EnteredEditMode:
               break;
            case PlayModeStateChange.ExitingEditMode:
               break;
            case PlayModeStateChange.EnteredPlayMode:
               if (CustomPlayButtonParameters.m_loadFirstScene) SceneManager.LoadScene(0);

               break;
            case PlayModeStateChange.ExitingPlayMode:
               break;
            default:
               throw new ArgumentOutOfRangeException(nameof(_obj), _obj, null);
         }
      }
   }
}
