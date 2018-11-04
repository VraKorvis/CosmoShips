using Entitas;
using Entitas.Unity;
using UnityEngine;

public class PoolableViewController : ViewController, IPoolableViewController {
    public virtual void PushToObjectPool() {
        var link = gameObject.GetEntityLink();
        var entity = (IViewObjectPoolEntity)link.entity;   
        entity.viewObjectPool.pool.Push(gameObject);     
    }
}
