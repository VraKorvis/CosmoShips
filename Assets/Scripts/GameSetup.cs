using Entitas.CodeGeneration.Attributes;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using static UnityEditorInternal.ReorderableList;

[CustomEditor(typeof(GameSetup))]
public class GameSetupEditor : Editor {

    private static float _elementHeight = 120;
    private ReorderableList _listBaseShips;
    private ReorderableList _listStatsShipsMultiply;

    void OnEnable() {

        _listBaseShips = new ReorderableList(serializedObject,
                serializedObject.FindProperty("baseShipsStats"),
                true, true, true, true);
        _listBaseShips.drawHeaderCallback += (Rect rect) => { EditorGUI.LabelField(rect, "                         Base Ships Stats           ", EditorStyles.boldLabel); };


        _listBaseShips.elementHeight = _elementHeight;
        _listBaseShips.drawElementCallback += delegate (Rect rect, int index, bool isActive, bool isFocused) {

            var element = _listBaseShips.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            SerializedProperty propertyType = element.FindPropertyRelative("type");
            if (propertyType.objectReferenceValue != null) {
                EditorGUI.LabelField(rect, propertyType.objectReferenceValue.name.ToString(), EditorStyles.boldLabel);
            }
            EditorGUI.PropertyField(new Rect(rect.x, rect.y + 15, rect.width - 60, EditorGUIUtility.singleLineHeight), propertyType, new GUIContent("Type"));
            EditorGUI.PropertyField(new Rect(rect.x, rect.y + 30, rect.width - 60, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("health"), new GUIContent("Health"));
            EditorGUI.PropertyField(new Rect(rect.x, rect.y + 45, rect.width - 60, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("shootSpeed"), new GUIContent("ShootSpeed"));
            EditorGUI.PropertyField(new Rect(rect.x, rect.y + 60, rect.width - 60, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("mooveSpeed"), new GUIContent("MooveSpeed"));
            EditorGUI.PropertyField(new Rect(rect.x, rect.y + 75, rect.width - 60, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("mobility"), new GUIContent("Mobility"));

        };

        _listStatsShipsMultiply = new ReorderableList(serializedObject,
                serializedObject.FindProperty("shipsStatsMultipliers"),
                true, true, true, true);

        _listStatsShipsMultiply.drawHeaderCallback += (Rect rect) => { EditorGUI.LabelField(rect, "                         Ships Stats Multiply           ", EditorStyles.boldLabel); };

        _listStatsShipsMultiply.elementHeight = _elementHeight;
        _listStatsShipsMultiply.drawElementCallback += (Rect rect, int index, bool isActive, bool isFocused) => {

            var element = _listStatsShipsMultiply.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            SerializedProperty propertyType = element.FindPropertyRelative("type");
            if (propertyType.objectReferenceValue != null) {
                EditorGUI.LabelField(rect, propertyType.objectReferenceValue.name.ToString(), EditorStyles.boldLabel);
            }            
            EditorGUI.PropertyField(new Rect(rect.x, rect.y + 15, rect.width - 60, EditorGUIUtility.singleLineHeight), propertyType, new GUIContent("Type"));
            EditorGUI.PropertyField(new Rect(rect.x, rect.y + 30, rect.width - 60, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("health"), new GUIContent("Health"));
            EditorGUI.PropertyField(new Rect(rect.x, rect.y + 45, rect.width - 60, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("shootSpeed"), new GUIContent("ShootSpeed"));
            EditorGUI.PropertyField(new Rect(rect.x, rect.y + 60, rect.width - 60, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("mooveSpeed"), new GUIContent("MooveSpeed"));
            EditorGUI.PropertyField(new Rect(rect.x, rect.y + 75, rect.width - 60, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("mobility"), new GUIContent("Mobility"));
            EditorGUI.PropertyField(new Rect(rect.x, rect.y + 90, rect.width - 60, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("weaponDamage"), new GUIContent("WeaponDamage"));
        };

    }

    public override void OnInspectorGUI() {
        serializedObject.Update();
        _listBaseShips.DoLayoutList();
        _listStatsShipsMultiply.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}

[CreateAssetMenu(menuName = "Stats/ShipStats", fileName = "ShipStats")]
[Game, Unique]
public class GameSetup : ScriptableObject {
    [SerializeField]
    public List<BaseShip> baseShipsStats ;
    [SerializeField]
    public List<ShipMultipliers> shipsStatsMultipliers;

    //void OnEnable() {
    //    if (baseShipsStats == null) {
    //        baseShipsStats = new List<BaseShip>();
    //    }
    //    if (shipsStatsMultipliers == null) {
    //        shipsStatsMultipliers = new List<ShipMultipliers>();
    //    }
    //}
}



