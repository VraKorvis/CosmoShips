using UnityEngine;
using System.Collections;

public interface IEnemyController : IPoolableViewController {
}


/// <summary>
/// TODO control enemy ship
/// </summary>
public class EnemyViewController : PoolableViewController, IEnemyController {

    public EffectsPlayer mDespawnEffects;

    void OnEnable() {
        // _rotation = _minRotation + (_baseRotation * new Random(0).Next(0, 1));       
    }

    public override void Hide(bool animated) {
        if (animated) {
            mDespawnEffects.Play(transform.position);
        }
        base.Hide(animated);
        PushToObjectPool();
        Reset();
    }

    public override void Hide(bool animated, Vector3 hitPos) {
        this.Hide(animated);
    }

}
