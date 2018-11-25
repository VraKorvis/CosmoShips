using Entitas;
using UnityEngine;
using System;
using Random = System.Random;
using Entitas.Unity;
using System.Collections;
using Object = System.Object;

public interface IBulletController : IPoolableViewController {
}

[RequireComponent(typeof(EffectsPlayer))]
public class BulletViewController : PoolableViewController, IBulletController {

    public EffectsPlayer _despawnEffects;
    private Transform _transform;
    [SerializeField]
    Vector3 _minRotation;

    [SerializeField]
    Vector3 _baseRotation;

    [SerializeField]
    float _randomRotationFactor;
   
    Vector3 _rotation;
    Vector3 movement;

    private void Awake() {
        _transform = GetComponent<Transform>();
        _despawnEffects = GetComponent<EffectsPlayer>();
    }

    private void Start() {
       // _despawnEffects = EffectsPlayerExtension._hitPool.Get();
    }
    void OnEnable() {
        // _rotation = _minRotation + (_baseRotation * new Random(0).Next(0, 1));       
    }

    void Update() {
        transform.Rotate(_rotation);
        // transform.position += Vector3.right *10.0f * Time.deltaTime;
    }

    public override void Hide(bool animated, Vector3 pos) {

        if (animated) {
            _despawnEffects.Play( Singleton<ManagerEffectsPool>.Instance._hitPool, pos);   
        }

        base.Hide(animated);
        PushToObjectPool();
        Reset();
    }

    public override void InitView(GameObject viewObject, IViewableEntity e) {
        base.InitView(viewObject, e);
        var urb = viewObject.GetComponent<UnityRigidbody>();
        if (urb != null) {
            e.AddUnityRigidbody(urb);
            e.unityRigidbody.value.Rigidbody.transform.position = e.unityTransform.value.position;
            e.unityRigidbody.value.Rigidbody.transform.rotation = e.unityTransform.value.localRotation;
            //OR
            // e.unityRigidbody.value.Rigidbody.transform.rotation = ShootingAtAnAngle(e); 
        }
        viewObject.Link(e, Contexts.sharedInstance.bullets);
        //ChangeMaterial(viewObject);
    }


    //TODO IF UPDATE!
    //make shooting with degree
    private Quaternion ShootingAtAnAngle(BulletsEntity e) {
        Vector3 old = e.unityTransform.value.localRotation.eulerAngles;
        return Quaternion.Euler(old.x, old.z, -old.y);
    }

    private void ChangeMaterial(GameObject go) {
        var material = Resources.Load<Material>(Res.RayLaser + RayLaser.Red);
        go.GetComponent<Renderer>().sharedMaterial = material;
    }
}
