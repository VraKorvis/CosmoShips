using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.Unity;

public interface IEnemyController : IPoolableViewController {
}

/// <summary>
/// TODO control enemy ship
/// </summary>

[RequireComponent(typeof(EffectsPlayer))]
public class EnemyViewController : PoolableViewController, IEnemyController {

    public EffectsPlayer _despawnEffects;
    private Transform _transform;

    private void Awake() {
        _transform = GetComponent<Transform>();
        _despawnEffects = GetComponent<EffectsPlayer>();
    }

    void OnEnable() {
        // _rotation = _minRotation + (_baseRotation * new Random(0).Next(0, 1));       
    }

    public override void Hide(bool animated, Vector3 pos) {
        if (animated) {
            _despawnEffects.PlayAll(pos);
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
        }

        var moveController = viewObject.GetComponent<MoveController>();
        if (moveController!=null){
            ((EnemiesEntity)e).AddMove(moveController);
        }
        viewObject.Link(e, Contexts.sharedInstance.enemies);

    }
}
