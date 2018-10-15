using UnityEngine;
using Entitas;
using System.Collections.Generic;
using Entitas.Unity;

public class InstantiateViewSystem : ReactiveSystem<GameEntity> {

    // ______________________just for test and check working commit github!!!!!!!!!!!!
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

    protected override void Execute(List<GameEntity> entities) {
        foreach (var entity in entities) {
            _viewService.LoadAsset(_contexts, entity);
        }
    }

}
