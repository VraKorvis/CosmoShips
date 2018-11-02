using Entitas.CodeGeneration.Attributes;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using static UnityEditorInternal.ReorderableList;

[CustomEditor(typeof(GameSetup))]
public class GameSetupEditor : Editor {

    private static float _elementHeightForBaseShipList = 120;
    private static float _elementHeightForStatsMultiply = 140;
    private static float _elementHeightIfHide = 20;
    private static float _lineSpacing = 18;
    private ReorderableList _listBaseShipsStats;
    private ReorderableList _listBaseShipsStatsEnemy;
    private ReorderableList _listShipsMultiplyStats;


    void OnEnable() {
        _listBaseShipsStats = new ReorderableList(serializedObject,
                        serializedObject.FindProperty("baseShipsStats"),
                        true, true, true, true);
        _listBaseShipsStats.drawHeaderCallback += (Rect rect) => { EditorGUI.LabelField(rect, "                         Base Ships Stats           ", EditorStyles.boldLabel); };

        SetUpAndDrawReorderableList(_listBaseShipsStats);
        _listBaseShipsStats.elementHeightCallback += (index) => {
            return _listBaseShipsStats.serializedProperty.GetArrayElementAtIndex(index).isExpanded ? _elementHeightForBaseShipList : _elementHeightIfHide;
        };

        _listBaseShipsStatsEnemy = new ReorderableList(serializedObject,
                     serializedObject.FindProperty("baseShipStatsEnemy"),
                     true, true, true, true);
        _listBaseShipsStatsEnemy.drawHeaderCallback += (Rect rect) => { EditorGUI.LabelField(rect, "                        Enemy Base Ships Stats           ", EditorStyles.boldLabel); };

        SetUpAndDrawReorderableList(_listBaseShipsStatsEnemy);
        _listBaseShipsStatsEnemy.elementHeightCallback += (index) => {
            return _listBaseShipsStatsEnemy.serializedProperty.GetArrayElementAtIndex(index).isExpanded ? _elementHeightForBaseShipList : _elementHeightIfHide;
        };

        _listShipsMultiplyStats = new ReorderableList(serializedObject,
                serializedObject.FindProperty("shipsStatsMultipliers"),
                true, true, true, true);

        _listShipsMultiplyStats.drawHeaderCallback += (Rect rect) => { EditorGUI.LabelField(rect, "                         Ships Stats Multiply           ", EditorStyles.boldLabel); };

        SetUpAndDrawReorderableList(_listShipsMultiplyStats);
        _listShipsMultiplyStats.elementHeightCallback += (index) => {
            return _listShipsMultiplyStats.serializedProperty.GetArrayElementAtIndex(index).isExpanded ? _elementHeightForStatsMultiply : _elementHeightIfHide;
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
            element.isExpanded = EditorGUI.Foldout(new Rect(rect.x + 15, rect.y + 2, rect.width / 4, 10),
                element.isExpanded, propertyName == null ? new GUIContent("Add player/enemy prefab") : new GUIContent(propertyName), false);

            if (element.isExpanded) {
                EditorGUI.PropertyField(new Rect(rect.x, rect.y + _lineSpacing, rect.width - 60, EditorGUIUtility.singleLineHeight), propertyType, new GUIContent("Type"));
                EditorGUI.PropertyField(new Rect(rect.x, rect.y + _lineSpacing * 2, rect.width - 60, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("health"), new GUIContent("Health"));
                EditorGUI.PropertyField(new Rect(rect.x, rect.y + _lineSpacing * 3, rect.width - 60, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("shootSpeed"), new GUIContent("ShootSpeed"));
                EditorGUI.PropertyField(new Rect(rect.x, rect.y + _lineSpacing * 4, rect.width - 60, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("mooveSpeed"), new GUIContent("MooveSpeed"));
                EditorGUI.PropertyField(new Rect(rect.x, rect.y + _lineSpacing * 5, rect.width - 60, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("mobility"), new GUIContent("Mobility"));
                SerializedProperty weaponDamage = element.FindPropertyRelative("weaponDamage");
                if (weaponDamage != null) {
                    EditorGUI.PropertyField(new Rect(rect.x, rect.y + 108, rect.width - 60, EditorGUIUtility.singleLineHeight), weaponDamage, new GUIContent("WeaponDamage"));
                }
            }
        };
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();
        EditorGUILayout.Space();
        ReorderableListUtility.DoLayoutListWithFoldout(_listBaseShipsStats);
        ReorderableListUtility.DoLayoutListWithFoldout(_listBaseShipsStatsEnemy);
        ReorderableListUtility.DoLayoutListWithFoldout(_listShipsMultiplyStats);
        serializedObject.ApplyModifiedProperties();
        EditorApplication.update.Invoke();
    }
}

[CreateAssetMenu(menuName = "Setup/GameSetup", fileName = "ShipStats(GameSetup)")]
[Game, Unique]
public class GameSetup : ScriptableObject {
    [SerializeField]
    public List<BaseShip> baseShipsStats;
    [SerializeField]
    public List<BaseShip> baseShipStatsEnemy;
    [SerializeField]
    public List<ShipMultipliers> shipsStatsMultipliers;

    public int Count() {
        return baseShipsStats != null ? baseShipsStats.Count : 0;
    }

    public BaseShip this[int index] {
        get { return baseShipsStats[index]; }
    }

    public ShipMultipliers GetItem(int index) {
        return shipsStatsMultipliers[index];
    }

}

//[CustomPropertyDrawer(Ingredient)]
//class IngredientDrawer : PropertyDrawer {

//    // Draw the property inside the given rect
//    void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
//        // Using BeginProperty / EndProperty on the parent property means that
//        // prefab override logic works on the entire property.
//        EditorGUI.BeginProperty(position, label, property);

//        // Draw label
//        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

//        // Don't make child fields be indented
//        var indent = EditorGUI.indentLevel;
//        EditorGUI.indentLevel = 0;

//        // Calculate rects
//        Rect amountRect = new Rect(position.x, position.y, 30, position.height);
//        Rect unitRect = new Rect(position.x + 35, position.y, 50, position.height);
//        Rect nameRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

//        // Draw fields - passs GUIContent.none to each so they are drawn without labels
//        EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("amount"), GUIContent.none);
//        EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("unit"), GUIContent.none);
//        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("name"), GUIContent.none);

//        // Set indent back to what it was
//        EditorGUI.indentLevel = indent;

//        EditorGUI.EndProperty();
//    }
//}



