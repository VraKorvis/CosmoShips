using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Entitas.Unity;

//TODO MultyAddViewFromObjectPool
public sealed class AddViewFromObjectPoolSystem : ReactiveSystem<BulletsEntity>, IInitializeSystem {
      
    Transform _container;

    public AddViewFromObjectPoolSystem(Contexts contexts) : base(contexts.bullets) {  }
  

    public void Initialize() {
        _container = new GameObject(Contexts.sharedInstance.bullets.contextInfo.name + " Views (Pooled)").transform;
    }

    protected override ICollector<BulletsEntity> GetTrigger(IContext<BulletsEntity> context) {
        return context.CreateCollector(BulletsMatcher.Bullet);
    }

    protected override bool Filter(BulletsEntity entity) {
        return entity.hasViewObjectPool;
    }   

    protected override void Execute(List<BulletsEntity> entities) {
        
        foreach (var e in entities) {
            GameObject gameObject = e.viewObjectPool.pool.Get();
            gameObject.SetActive(true);
            gameObject.transform.SetParent(_container, false);
            e.AddView(gameObject);
            gameObject.Link(e, Contexts.sharedInstance.bullets);
          
            var urb = gameObject.GetComponent<UnityRigidbody>();
            if (urb!=null) {
                e.AddRigidbody(urb);
                e.rigidbody.value._rigidbody.transform.position = Contexts.sharedInstance.game.playerEntity.rigidbody.value._rigidbody.transform.position;
            }
            var viewController = gameObject.GetComponent<IPoolableViewController>();
            e.AddViewControll(viewController);
        }
    }

}
