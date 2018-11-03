using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Entitas.Unity;



public interface IAddViewFromObjectPool : IEntity, IViewObjectPoolEntity { }


public partial class BulletsEntity : IAddViewFromObjectPool { }

public partial class EnemiesEntity : IAddViewFromObjectPool { }

public sealed class AddViewFromObjectPoolSystem : MultiReactiveSystem<IAddViewFromObjectPool, Contexts>, IInitializeSystem {
      
    Transform _container;

    public AddViewFromObjectPoolSystem(Contexts contexts) : base(contexts) {  }
  

    public void Initialize() {
        _container = new GameObject(Contexts.sharedInstance.bullets.contextInfo.name + " Views (Pooled)").transform;
    }

    protected override ICollector[] GetTrigger(Contexts contexts) {
        throw new NotImplementedException();
    }

    protected override bool Filter(IAddViewFromObjectPool entity) {
        throw new NotImplementedException();
    }   

    protected override void Execute(List<IAddViewFromObjectPool> entities) {
        
        foreach (var e in entities) {
            GameObject gameObject = e.viewObjectPool.pool.Get();
            gameObject.SetActive(true);
            gameObject.transform.SetParent(_container, false);            
            gameObject.Link(e, Contexts.sharedInstance.bullets);
         //   e.AddViewBullet(gameObject.GetComponent<IViewController>());
            var urb = gameObject.GetComponent<UnityRigidbody>();
            if (urb!=null) {
           //     e.AddRigidbody(urb);
           //     e.rigidbody.value._rigidbody.transform.position = Contexts.sharedInstance.game.playerEntity.rigidbody.value._rigidbody.transform.position;
            }
        }
    }


}
