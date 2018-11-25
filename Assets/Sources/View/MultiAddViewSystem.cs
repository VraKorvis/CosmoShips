using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;
using Entitas.Unity;

public interface IViewableEntity : IEntity, IAssignViewEntity, IViewEntity, IUnityRigidbodyEntity, IViewObjectPoolEntity, IViewControllEntity, IUnityTransformEntity { }

public partial class BulletsEntity : IViewableEntity { }
public partial class EnemiesEntity : IViewableEntity { }


public class MultiAddViewSystem : MultiReactiveSystem<IViewableEntity, Contexts> {

    private Contexts _contexts;

    private readonly Transform _topViewContainer = new GameObject("Views Pool").transform;
    private readonly Dictionary<string, Transform> _viewContainersMap = new Dictionary<string, Transform>();

    private readonly List<IEventListener> _eventListenerBuffer;

    public MultiAddViewSystem(Contexts contexts) : base(contexts) {
        this._contexts = contexts;
        _eventListenerBuffer = new List<IEventListener>(16);
        // create container foreach contexts
        foreach (var context in contexts.allContexts) {
            string contextName = context.contextInfo.name;
            Transform contextViewContainer = new GameObject(contextName + " Views").transform;
            contextViewContainer.SetParent(_topViewContainer);
            _viewContainersMap.Add(contextName, contextViewContainer);
        }
    }

    protected override ICollector[] GetTrigger(Contexts contexts) {
        return new ICollector[] {
           contexts.enemies.CreateCollector(EnemiesMatcher.AssignView),
           contexts.bullets.CreateCollector(BulletsMatcher.AssignView)
       };
    }

    protected override bool Filter(IViewableEntity entity) {
        return !entity.hasView && entity.isAssignView && entity.hasViewObjectPool;
    }

    protected override void Execute(List<IViewableEntity> entities) {
       
        foreach (var e in entities) {
            var viewObject = e.viewObjectPool.pool.Get();
            viewObject.SetActive(true);

            string contextName = e.contextInfo.name;
            viewObject.transform.SetParent(_viewContainersMap[contextName]);
            e.AddView(viewObject); 

            var poolViewController = viewObject.GetComponent<IPoolableViewController>();
            e.AddViewControll(poolViewController);                     

            e.isAssignView = false;
            poolViewController.InitView(viewObject, e);

            viewObject.GetComponents(_eventListenerBuffer);
            foreach (var listener in _eventListenerBuffer) {
                listener.RegisterListeners(e);
            }
        }
    }



}
