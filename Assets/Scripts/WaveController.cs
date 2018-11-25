using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WaveController : MonoBehaviour {

    public int lvl; 
    [SerializeField]
    public List<GameObject[]> _lvlWaves;
    public GameObject[] _waves;
    private int numberWave;

    [HideInInspector]
    public Vector3[] _positions;
    [HideInInspector]
    public Vector3 currentPos;
    [HideInInspector]
    public int currentIndex;

    private void Awake() {
       // _waves = _lvlWaves[lvl];
        var line = _waves[numberWave].GetComponent<LineRenderer>();
        _positions =  new Vector3[line.positionCount];
        line.GetPositions(_positions);
        currentPos = _positions[currentIndex];
    }

    public void NextWave() {
        var line = _waves[Mathf.Clamp(++numberWave, 0, _waves.Length - 1)].GetComponent<LineRenderer>();       
        line.GetPositions(_positions);       
    }


}
