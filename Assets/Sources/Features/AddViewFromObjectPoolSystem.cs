using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Entitas.Unity;

public sealed class AddViewFromObjectPoolSystem : ReactiveSystem<BulletsEntity>, IInitializeSystem {

    Contexts _contexts;
    Transform _container;

    public AddViewFromObjectPoolSystem(Contexts contexts) : base(contexts.bullets) {       
        _contexts = contexts;
    }

    public void Initialize() {
        _container = new GameObject(_contexts.bullets.contextInfo.name + " Views (Pooled)").transform;
    }

    protected override ICollector<BulletsEntity> GetTrigger(IContext<BulletsEntity> context) {
       return context.CreateCollector(BulletsMatcher.ViewObjectPool);
    }

    protected override bool Filter(BulletsEntity entity) {        
        return entity.hasViewObjectPool;
    }

    protected override void Execute(List<BulletsEntity> entities) {
        
        foreach (var e in entities) {
            GameObject gameObject = e.viewObjectPool.pool.Get();
            gameObject.SetActive(true);
            gameObject.transform.SetParent(_container, false);            
            gameObject.Link(e, _contexts.bullets);
            e.AddViewBullet(gameObject.GetComponent<IViewController>());
            var urb = gameObject.GetComponent<UnityRigidbody>();
            if (urb!=null) {
                e.AddRigidbody(urb);
                e.rigidbody.value._rigidbody.transform.position = _contexts.game.playerEntity.rigidbody.value._rigidbody.transform.position;
            }
        }
    }
}
