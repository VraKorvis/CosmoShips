using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour {

    public Camera camera;
    private float lastHeight = 0;

    void OnEnable() {
        if (!camera) {
            Debug.Log("Camera is not set");
            enabled = false;
        }
    }

    void Update() {
        if (lastHeight != Screen.height) {
            lastHeight = Screen.height;
            camera.orthographicSize = 7.68f;
        }
    }
}
