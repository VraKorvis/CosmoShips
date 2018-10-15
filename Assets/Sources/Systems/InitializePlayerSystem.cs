using UnityEngine;
using Entitas;

public class InitializePlayerSystem : IInitializeSystem {

    private Contexts _contexts;
    private IViewService _viewService;

    public InitializePlayerSystem(Contexts contexts, IViewService viewService) {
        _contexts = contexts;
        _viewService = viewService;
    }
    public void Initialize() {
        var entity = _contexts.game.CreateEntity();
        entity.isPlayer = true;
        _viewService.LoadAsset(_contexts, entity);


    }
}
