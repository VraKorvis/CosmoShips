using UnityEngine;
using System.Collections;
using System;
using Entitas.Unity;

public interface IPlayerController : IPoolableViewController { }

[RequireComponent(typeof(EffectsPlayer))]
public class PlayerViewController : PoolableViewController, IPlayerController {

    public EffectsPlayer _despawnEffects;
    private Transform _transform;
    [HideInInspector]
    public Vector3 _shootVector = Vector3.up;

    public override void Hide(bool animated, Vector3 pos) {
        if (animated) {
            _despawnEffects.PlayAll(pos);
        }

        base.Hide(animated);
        Reset();
    }

    private void Awake() {
        _transform = GetComponent<Transform>();
        _despawnEffects = GetComponent<EffectsPlayer>();
    }

    private void Start() {
        StartCoroutine(ShootRay());
    }
    /// <summary>
    /// Search enemy in deep z 
    /// </summary>
    /// <returns></returns>
    private IEnumerator ShootRay() {
        RaycastHit hit;
        while (true) {
            for (int i = -1; i < 30; i++) {
                int deg = i * 3;
                Vector3 nVec;

                nVec = Quaternion.Euler(deg, 0f, 0f) * Vector3.up;

                if (Physics.Raycast(_transform.position, nVec, out hit, 1000)) {
                    // Debug.Log(i + " " + hit.point.ToString() + "       eulers:   " + nVec);          
                    if (deg < 30)
                        _shootVector = nVec;
                    else
                        _shootVector = Quaternion.Euler(7, 0f, 0f) * nVec;
                    Debug.DrawRay(_transform.position, nVec * 30, (i & (i - 1)) == 0 ? (Color.green) : Color.red);
                    break;
                }
            }
            yield return null;
        }
    }
}
