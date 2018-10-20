using UnityEngine;
using Entitas;
using System;
using Object = UnityEngine.Object;
using Entitas.Unity;

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
        _viewService.LoadAsset(entity, 0, 0);        
        entity.AddHealth(entity.baseShipStats.baseShip.health * entity.shipsStatsMultipliers.shipMultipliers.health);
       
    }
}
