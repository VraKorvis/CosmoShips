using UnityEngine;
using System.Collections;
using UnityEditor;

public class WaveSetupEditor : Editor {

    void OnEnable() {

    }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
    }
}

public class WaveSetup : ScriptableObject { }