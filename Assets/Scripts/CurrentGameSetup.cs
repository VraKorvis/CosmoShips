using Entitas.CodeGeneration.Attributes;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CurrentGameSetup))]
public class CurrentGameSetupEditor : Editor {
    void OnInspecotrGui() {
        // serializedObject.Update();
        //EditorGUILayout.Space();       
        //serializedObject.ApplyModifiedProperties();
        //EditorApplication.update.Invoke();
    }
}

[CreateAssetMenu(menuName = "Setup/CurrentGame", fileName = "CurrentGame")]
[Game, Unique]
[EntityIndex]
public class CurrentGameSetup : ScriptableObject {
    [SerializeField]
    public int lvlID;
    [SerializeField]
    public int shipID;
    [SerializeField]
    public int rocketID;
    [SerializeField]
    public int laserID;
       
}
