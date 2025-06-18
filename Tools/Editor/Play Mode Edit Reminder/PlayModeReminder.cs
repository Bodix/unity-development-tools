using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class PlayModeReminder
{
    // TODO: 
    // 1. Make the reminder active whenever there is at least one change in the scene.
    // 2. Add toggling the reminder on and off. Also make it off by default.
    
    private static GUIStyle _style;

    static PlayModeReminder()
    {
        SceneView.duringSceneGui += DrawReminderText;
    }

    private static void DrawReminderText(SceneView view)
    {
        if (Application.isPlaying && Selection.activeGameObject != null &&
            Selection.activeGameObject.scene.name != null)
        {
            if (_style == null)
            {
                _style = new GUIStyle(GUI.skin.GetStyle("label"))
                {
                    fontSize = 20,
                    contentOffset = Vector2.zero,
                    overflow = new RectOffset(),
                    margin = new RectOffset(0, 0, 0, 40),
                    alignment = TextAnchor.LowerCenter,
                    fontStyle = FontStyle.Bold,
                    wordWrap = true,
                    stretchHeight = true
                };
            }

            float color = Mathf.Sin(Time.realtimeSinceStartup * 15f) * 0.5f + 0.5f;
            _style.normal.textColor = new Color(1f, color, color, 1f);

            Handles.BeginGUI();
            GUILayout.Label("PLAY MODE IS ACTIVE", _style);
            Handles.EndGUI();
        }
    }
}