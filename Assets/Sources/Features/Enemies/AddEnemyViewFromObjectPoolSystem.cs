using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Entitas.Unity;
public class AddEnemyViewFromObjectPoolSystem : ReactiveSystem<EnemiesEntity>, IInitializeSystem {
    Transform _container;
    private Contexts _contexts;
    public AddEnemyViewFromObjectPoolSystem(Contexts contexts) : base(contexts.enemies) {
        _contexts = contexts;
    }


    public void Initialize() {
        _container = new GameObject(Contexts.sharedInstance.enemies.contextInfo.name + " Views (Pooled)").transform;
    }

    protected override ICollector<EnemiesEntity> GetTrigger(IContext<EnemiesEntity> context) {
        return context.CreateCollector(EnemiesMatcher.Enemy);
    }


    protected override bool Filter(EnemiesEntity entity) {
        return entity.hasViewObjectPool;
    }

    protected override void Execute(List<EnemiesEntity> entities) {
        
        foreach (var e in entities) {
            GameObject gameObject = e.viewObjectPool.pool.Get();
            gameObject.SetActive(true);
            gameObject.transform.SetParent(_container, false);
            e.AddView(gameObject);
            gameObject.Link(e, _contexts.enemies); 
            
            var urb = gameObject.GetComponent<UnityRigidbody>();
            if (urb != null) {
                e.AddRigidbody(urb);
                e.rigidbody.value._rigidbody.transform.position = _container.position;
                Vector3 pos = e.rigidbody.value._rigidbody.transform.position;
                pos.z = -5.0f;
                e.rigidbody.value._rigidbody.transform.position = pos;
            }

            var poolViewController = gameObject.GetComponent<IPoolableViewController>();
            e.AddViewControll(poolViewController);
        }
    }
}
