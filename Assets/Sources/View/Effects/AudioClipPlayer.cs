using UnityEngine;
using System.Collections;

public class AudioClipPlayer : MonoBehaviour {

    public AudioSource audioSource;
    public float randomizePitch;
    // Use this for initialization

    public int startingPitch=1;
    public int timeToDecrease=5;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable() {
        audioSource.pitch = startingPitch;
        audioSource.Play();
    }

    private void Update() {
        if (audioSource.pitch > 0)
            audioSource.pitch -= Time.deltaTime * startingPitch / timeToDecrease;
    }


}
