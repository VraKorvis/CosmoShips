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

    private static float _elementHeigh = 80;
    private static float _elementHeightIfHide = 20;
    private static float _lineSpacing = 18;

    private void OnEnable() {
        _lasers = new ReorderableList(serializedObject,
                        serializedObject.FindProperty("lasers"),
                        true, true, true, true);
        _lasers.drawHeaderCallback += (Rect rect) => { EditorGUI.LabelField(rect, "                         Lasers           ", EditorStyles.boldLabel); };

        SetUpAndDrawReorderableList(_lasers);
        _lasers.elementHeightCallback += (index) => {
            return _lasers.serializedProperty.GetArrayElementAtIndex(index).isExpanded ? _elementHeigh : _elementHeightIfHide;
        };
        _rockets = new ReorderableList(serializedObject,
                        serializedObject.FindProperty("rockets"),
                        true, true, true, true);
        _rockets.drawHeaderCallback += (Rect rect) => { EditorGUI.LabelField(rect, "                         Rockets           ", EditorStyles.boldLabel); };

        SetUpAndDrawReorderableList(_rockets);

        _rockets.elementHeightCallback += (index) => {
            return _rockets.serializedProperty.GetArrayElementAtIndex(index).isExpanded ? _elementHeigh : _elementHeightIfHide;
        };
    }

    private void SetUpAndDrawReorderableList(ReorderableList list) {
        list.drawElementCallback += delegate (Rect rect, int index, bool isActive, bool isFocused) {

            var element = list.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            SerializedProperty propertyType = element.FindPropertyRelative("type");

            if (propertyType == null) {
                element.isExpanded = false;
                return;
            }

            string propertyName = null;
            if (propertyType.objectReferenceValue != null) {
                propertyName = propertyType.objectReferenceValue.name.ToString();
            }

            element.isExpanded = EditorGUI.Foldout(new Rect(rect.x + 10, rect.y, rect.width / 4, 20),
                element.isExpanded, propertyName == null ? new GUIContent("Type") : new GUIContent(propertyName), false);

            if (element.isExpanded) {
                EditorGUI.PropertyField(new Rect(rect.x + 70, rect.y, rect.width, EditorGUIUtility.singleLineHeight), propertyType, GUIContent.none);

                SerializedProperty weaponCharacteristic = element.FindPropertyRelative("weaponCharacteristic");

                //weaponCharacteristic.isExpanded = EditorGUI.Foldout(new Rect(rect.x, rect.y + _lineSpacing, rect.width / 4, 20),
                //    weaponCharacteristic.isExpanded, weaponCharacteristic == null ? new GUIContent("weaponCharacteristic") : new GUIContent(weaponCharacteristic.name), false);

                EditorGUI.PropertyField(new Rect(rect.x, rect.y + _lineSpacing * 1, rect.width - 60, EditorGUIUtility.singleLineHeight), weaponCharacteristic.FindPropertyRelative("damage"), new GUIContent("damage"));
                EditorGUI.PropertyField(new Rect(rect.x, rect.y + _lineSpacing * 2, rect.width - 60, EditorGUIUtility.singleLineHeight), weaponCharacteristic.FindPropertyRelative("speed"), new GUIContent("speed"));
                EditorGUI.PropertyField(new Rect(rect.x, rect.y + _lineSpacing * 3, rect.width - 60, EditorGUIUtility.singleLineHeight), weaponCharacteristic.FindPropertyRelative("isHoming"), new GUIContent("isHoming"));
            }
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
    [SerializeField]
    public WeaponCharacteristic weaponCharacteristic;
}

[Serializable]
public class Rocket {
    [SerializeField]
    public GameObject type;
    [SerializeField]
    public WeaponCharacteristic weaponCharacteristic;
}

//[CreateAssetMenu(menuName = "Setup/WeaponCharacteristic", fileName = "weaponCharacteristic")]
[Game, Unique]
[Serializable]
public class WeaponCharacteristic {
    [SerializeField]
    public int damage;
    [SerializeField]
    public int speed;
    [SerializeField]
    public bool isHoming;
}