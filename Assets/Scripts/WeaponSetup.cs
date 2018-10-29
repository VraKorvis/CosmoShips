using Entitas.CodeGeneration.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(WeaponSetup))]
public class WeaponSetupEditor : Editor {

    private ReorderableList _lasers;
    private ReorderableList _rockets;

    private void OnEnable() {
        _lasers = new ReorderableList(serializedObject,
                        serializedObject.FindProperty("lasers"),
                        true, true, true, true);
        _lasers.drawHeaderCallback += (Rect rect) => { EditorGUI.LabelField(rect, "                         Lasers           ", EditorStyles.boldLabel); };

        SetUpAndDrawReorderableList(_lasers);   

        _rockets = new ReorderableList(serializedObject,
                        serializedObject.FindProperty("rockets"),
                        true, true, true, true);
        _rockets.drawHeaderCallback += (Rect rect) => { EditorGUI.LabelField(rect, "                         Rockets           ", EditorStyles.boldLabel); };

        SetUpAndDrawReorderableList(_rockets);        
    }

    private void SetUpAndDrawReorderableList(ReorderableList list) {
        list.drawElementCallback += delegate (Rect rect, int index, bool isActive, bool isFocused) {

            var element = list.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            SerializedProperty propertyType = element.FindPropertyRelative("type");
            if (propertyType == null) {               
                return;
            }
            EditorGUI.LabelField(new Rect(rect.x + 15, rect.y, rect.width / 4, 20), "Type");
            EditorGUI.PropertyField(new Rect(rect.x + 60, rect.y, rect.width, EditorGUIUtility.singleLineHeight), propertyType, GUIContent.none);    
        };
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();
        EditorGUILayout.Space();
        ReorderableListUtility.DoLayoutListWithFoldout(_lasers);
        ReorderableListUtility.DoLayoutListWithFoldout(_rockets);
        
        serializedObject.ApplyModifiedProperties();
        EditorApplication.update.Invoke();
    }

}

[CreateAssetMenu(menuName = "Setup/Weapon", fileName = "weaponSetup")]
[Game, Unique]
public class WeaponSetup : ScriptableObject {

    [SerializeField]
    public List<Laser> lasers;
    [SerializeField]
    public List<Rocket> rockets;
}

[Serializable]
public class Laser {
    [SerializeField]
    public GameObject type;
}

[Serializable]
public class Rocket {
    [SerializeField]
    public GameObject type;
}
