using Entitas.CodeGeneration.Attributes;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(LevelSetup))]
public class LevelSetupEdit : Editor {

    private ReorderableList _levels;

    private static float _elementHeight = 60;
    private static float _elementHeightIfHide = 20;

    private void OnEnable() {

        _levels = new ReorderableList(serializedObject,
                        serializedObject.FindProperty("levels"),
                        true, true, true, true);

        _levels.drawElementCallback += (Rect rect, int index, bool isActive, bool isFocused) => {

            var element = _levels.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            SerializedProperty propertyType = element.FindPropertyRelative("name");            

            if (propertyType == null) {
                element.isExpanded = false;
                return;
            }
            string property_tmp = propertyType.ToString();           
            if (propertyType != null) 
                property_tmp = propertyType.stringValue;
            
            element.isExpanded = EditorGUI.Foldout(new Rect(rect.x + 15, rect.y + 2, rect.width / 4, 10),
                element.isExpanded, property_tmp == null ? new GUIContent("Add level") : new GUIContent(property_tmp), false);

           
            if (element.isExpanded) {                
                EditorGUI.PropertyField(new Rect(rect.x, rect.y + 18, rect.width - 10, EditorGUIUtility.singleLineHeight), propertyType, new GUIContent("Name"));                
                EditorGUI.PropertyField(new Rect(rect.x, rect.y + 36, rect.width - 10, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("background"), new GUIContent("Background"));
            }
        };

        _levels.elementHeightCallback += (int index) => {
            return _levels.serializedProperty.GetArrayElementAtIndex(index).isExpanded ? _elementHeight : _elementHeightIfHide;
        };
    }

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


        serializedObject.Update();
        EditorGUILayout.Space();
        ReorderableListUtility.DoLayoutListWithFoldout(_levels);        
        serializedObject.ApplyModifiedProperties();
        EditorApplication.update.Invoke();
    }



    //public void OnSceneGUI() {
    //    LevelSetup levelSetup = (LevelSetup)target;
    //    Handles.BeginGUI();
    //    Rect rect = new Rect(0, 0, 500, 500);
    //    GUI.Box(rect, "");
    //    Handles.EndGUI();
    //    Handles.color = Color.red;
    //    Handles.DrawLine(levelSetup.transform.position, levelSetup.transform.position+levelSetup.transform.forward);
    //}
}

//[ExecuteInEditMode]
[CreateAssetMenu(menuName = "LVL", fileName = "lvlSetup")]
[Game, Unique]
public class LevelSetup : ScriptableObject {

    [SerializeField]
    public int levelID;
    [SerializeField]
    public string path;
    [SerializeField]
    public List<Level> levels;

}

