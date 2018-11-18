using UnityEngine;
using System.Collections;
using System;

public delegate void FallowToPlayerEvent(Transform playerT);

public class CameraSettings : MonoBehaviour {

    private Transform _transform;
    private Vector3 _defaultPos;


    private void Awake() {
        _transform = GetComponent<Transform>();
        _defaultPos = _transform.position;
        ScreenBorder.OnFallow += Fallow;
        // ScreenBorder.OnBorderOut2 += Fallow;

        ScreenBorder.OnReturnToCenter += StopFallow;
    }
    
    private void Fallow(Transform playerT) {
        StartCoroutine(FallowToPlayer(playerT));
    }

    private IEnumerator FallowToPlayer(Transform playerT) {
        while (true) {
            Vector3 pos = _transform.position;
            pos.x = Mathf.Clamp(playerT.position.x, -6, 6);
            _transform.position = Vector3.Lerp(_transform.position, pos, Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }

    private void StopFallow(Transform playerT) {
        StopCoroutine(FallowToPlayer(playerT));
    }

}
