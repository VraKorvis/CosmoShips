using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackroundInit : MonoBehaviour {

    public Material material;
    public Texture texture;
    public CurrentGameSetup currentGameSetup;
    public LevelSetup levelSetup;
    private AudioSource audioSource;

    private void Awake() {
        int lvlID = currentGameSetup.lvlID;
        texture = levelSetup.levels[lvlID].background;
        material.SetTexture("_Background", texture);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = levelSetup.levels[lvlID].audioClip;
    }

    private void Start() {       
        audioSource.Play();
    }

}
