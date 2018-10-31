using Entitas;
using Entitas.Unity;
using UnityEngine;

public class PoolableViewController : ViewController, IPoolableViewController {
    public virtual void PushToObjectPool() {
        var link = gameObject.GetEntityLink();
        var entity = link.entity as BulletsEntity;
        
        Debug.Log("пуш в Пул PoolableViewController: (TODO)" + entity);
       
        entity.viewObjectPool.pool.Push(gameObject);
    }
}
