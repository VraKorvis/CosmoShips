using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackroundInit : MonoBehaviour {

    public Material material;
    public Texture[] texture;
    public CurrentGameSetup currentGameSetup;

    private void Awake() {
        int count = texture.Length-1;
        int lvlID = currentGameSetup.lvlID > texture.Length ? Random.Range(0, count) : currentGameSetup.lvlID;
        material.SetTexture("_Background", texture[lvlID]);
    }

}
