using UnityEngine;
using Entitas;
using System.Collections.Generic;
using Entitas.Unity;
using System;
using Object = UnityEngine.Object;

public class InstantiateViewSystem : ReactiveSystem<GameEntity>, IInitializeSystem {
    
    private IViewService _viewService;
    private Contexts _contexts;

    public InstantiateViewSystem(Contexts contexts, IViewService viewService) : base(contexts.game) {
        _contexts = contexts;
        _viewService = viewService;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Resource);
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasResource;
    }

    public void Initialize() {

    }

    protected override void Execute(List<GameEntity> entities) {
        foreach (var entity in entities) {
           
            var viewObject = Object.Instantiate(entity.resource.prefab);

            if (viewObject == null)
                throw new NullReferenceException("Prefabs not found!");

            entity.AddView(viewObject);

            var rigidbody = viewObject.GetComponent<IRigidbody>();
            if (rigidbody != null)
                entity.AddRigidbody(rigidbody);

            entity.AddPosition(viewObject.transform.position);
           
            viewObject.Link(entity, _contexts.game);

            if (entity.hasInitialPosition) {
                viewObject.transform.position = entity.initialPosition.value;
            }
        }
    }

    
}
