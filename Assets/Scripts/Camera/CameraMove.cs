using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public float speed = 0.01f;

    void Update() {
        Vector3 position = transform.position;
        position.y -= speed;
       // transform.position = position;
    }
}
