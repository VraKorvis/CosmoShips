using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Entitas.Unity;
public class AddEnemyViewFromObjectPoolSystem : ReactiveSystem<EnemiesEntity>, IInitializeSystem {

    Transform _container;
    private Contexts _contexts;

    readonly List<IEventListener> _eventListenerBuffer;

    public AddEnemyViewFromObjectPoolSystem(Contexts contexts) : base(contexts.enemies) {
        _contexts = contexts;
        _eventListenerBuffer = new List<IEventListener>(16);
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
            var viewObject = e.viewObjectPool.pool.Get();
            viewObject.SetActive(true);
            viewObject.transform.SetParent(_container, false);
            e.AddView(viewObject);
            viewObject.Link(e, _contexts.enemies); 
            
            var urb = viewObject.GetComponent<UnityRigidbody>();
            if (urb != null) {
                e.AddUnityRigidbody(urb);
                e.unityRigidbody.value.Rigidbody.transform.position = _container.position;            
            }

            var poolViewController = viewObject.GetComponent<IPoolableViewController>();
            e.AddViewControll(poolViewController);

            viewObject.GetComponents(_eventListenerBuffer);
            foreach (var listener in _eventListenerBuffer) {
                listener.RegisterListeners(e);
            }
        }
    }
}
