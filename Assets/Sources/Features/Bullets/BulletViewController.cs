using Entitas;
using UnityEngine;
using System;
using Random = System.Random;

public interface IBulletController : IPoolableViewController {
}

public class BulletViewController : PoolableViewController, IBulletController {

    public EffectsPlayer _despawnEffects;

    [SerializeField]
    Vector3 _minRotation;

    [SerializeField]
    Vector3 _baseRotation;

    [SerializeField]
    float _randomRotationFactor;

    //[SerializeField]
    // EffectPlayer _despawnEffects;

    Vector3 _rotation;
    Vector3 movement;

    void OnEnable() {
        // _rotation = _minRotation + (_baseRotation * new Random(0).Next(0, 1));       
    }

    void Update() {
        transform.Rotate(_rotation);
        // transform.position += Vector3.right *10.0f * Time.deltaTime;
    }

    public override void Hide(bool animated) {
        if (animated) {
            _despawnEffects.Play(transform.position);
        }

        base.Hide(animated);
        PushToObjectPool();
        Reset();
    }

    public override void Hide(bool animated, Vector3 hitPos) {
        if (animated) {
            _despawnEffects.Play(hitPos);
        }

        base.Hide(animated);
        PushToObjectPool();
        Reset();
    }
}
