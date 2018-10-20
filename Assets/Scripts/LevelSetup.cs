using Entitas.CodeGeneration.Attributes;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelSetup))]
public class LevelSetupEdit : Editor {

    public override void OnInspectorGUI() {
        //base.OnInspectorGUI();
        LevelSetup levelSetup = (LevelSetup)target;
        levelSetup.levelID = EditorGUILayout.IntField("Level number", levelSetup.levelID);
        if (levelSetup.levelID <= EditorBuildSettings.scenes.Length - 1) {
            var pathScene = EditorBuildSettings.scenes[levelSetup.levelID];
            EditorGUILayout.LabelField("Level - " + pathScene.path + " " + pathScene.enabled);
        } else {
            EditorGUILayout.LabelField("Scene/level - " + levelSetup.levelID + " Not Found");
        }
    }

    public void OnSceneGUI() {
        LevelSetup levelSetup = (LevelSetup)target;
        Handles.BeginGUI();
        Rect rect = new Rect(0, 0, 500, 500);
        GUI.Box(rect, "");
        Handles.EndGUI();
        Handles.color = Color.red;
        Handles.DrawLine(levelSetup.transform.position, levelSetup.transform.position+levelSetup.transform.forward);
    }
}

//[ExecuteInEditMode]
//[CreateAssetMenu(menuName = "LVL", fileName = "lvlSetup")]
[Game, Unique]
public class LevelSetup : MonoBehaviour {

    public int levelID;
    public string path;
}
