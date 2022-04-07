using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class CustomPlayButtonEditorWindow : EditorWindow
    {
        private bool m_loadFirstScene;
        [MenuItem("Tools/Play Button Behaviour")]
        public static void OpenWindow()
        {
            var window = (CustomPlayButtonEditorWindow)GetWindow(typeof(CustomPlayButtonEditorWindow),false,"Play Button Options");
            window.Show();
        }

        private void OnGUI()
        {
            GUILayout.Label("Play Button parameters");
            m_loadFirstScene = GUILayout.Toggle(m_loadFirstScene, "Load first scene");
            CustomPlayButtonParameters.m_loadFirstScene = m_loadFirstScene;
            GUILayout.Space(20);
            GUILayout.BeginHorizontal();
            GUI.enabled = !EditorApplication.isPlaying&&!EditorApplication.isCompiling;
            if (GUILayout.Button("Launch Play Mode"))EditorApplication.EnterPlaymode();
            GUI.enabled = EditorApplication.isPlaying;
            if (GUILayout.Button("Exit Play Mode"))EditorApplication.ExitPlaymode();
            GUI.enabled = true;
            GUILayout.EndHorizontal();
        }
    }


    public static class CustomPlayButtonParameters
    {
        public static bool m_loadFirstScene;
    }
}