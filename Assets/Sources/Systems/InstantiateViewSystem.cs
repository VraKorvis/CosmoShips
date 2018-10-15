using UnityEngine;
using Entitas;
using System.Collections.Generic;
using Entitas.Unity;

public class InstantiateViewSystem : ReactiveSystem<GameEntity> {

    private IViewService _service;
    private Contexts _contexts;

    public InstantiateViewSystem(Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
    }  

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Resource);
    }

    protected override bool Filter(GameEntity entity) {
       return entity.hasResource;
    }

    protected override void Execute(List<GameEntity> entities) {
        foreach (var entity in entities) {
            _service.LoadAsset(_contexts, entity);
        }
    }

   
}
