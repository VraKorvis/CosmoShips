using UnityEngine;
using System.Collections;
using System;

public delegate void FallowToPlayerEvent(Transform playerT);

public class CameraSettings : MonoBehaviour {

    private Transform _transform;
    public float leftBorder;
    public float rightBorder;
    public float speedFallow;

    private void Awake() {
        _transform = GetComponent<Transform>();       
        ScreenBorder.OnFallow += Fallow;
        // ScreenBorder.OnBorderOut2 += Fallow;

    }
    
    private void Fallow(Transform playerT) {
        StartCoroutine(FallowToPlayer(playerT));
    }

    private IEnumerator FallowToPlayer(Transform playerT) {
        while (true) {
            Vector3 pos = _transform.position;            
            pos.x = Mathf.Clamp(playerT.position.x, leftBorder, rightBorder);
            _transform.position = Vector3.Lerp(_transform.position, pos, Time.deltaTime* speedFallow);
            yield return new WaitForFixedUpdate();
        }
    }

    private void StopFallow(Transform playerT) {
        StopCoroutine(FallowToPlayer(playerT));
    }

}
