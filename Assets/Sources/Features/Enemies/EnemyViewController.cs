using UnityEngine;
using System.Collections;

public interface IEnemyController : IPoolableViewController {
}


/// <summary>
/// TODO control enemy ship
/// </summary>
public class EnemyViewController : PoolableViewController, IEnemyController {



    void OnEnable() {
        // _rotation = _minRotation + (_baseRotation * new Random(0).Next(0, 1));       
    }

    void Update() {
      
    }

    public override void Hide(bool animated) {
        if (animated) {
            //  _despawnEffects.Play(transform.position);
        }

        base.Hide(animated);
        PushToObjectPool();
        Reset();
    }


}
