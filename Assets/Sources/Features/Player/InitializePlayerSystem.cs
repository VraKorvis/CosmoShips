using UnityEngine;
using Entitas;
using System;
using Object = UnityEngine.Object;
using Entitas.Unity;

public class InitializePlayerSystem : IInitializeSystem {

    private Contexts _contexts;
    private AssetViewService _assetViewService;

    public InitializePlayerSystem(Contexts contexts, Services services) {
        this._contexts = contexts;
        this._assetViewService = services.assetViewService;
    }
    public void Initialize() {
        var entity = _contexts.game.CreateEntity();
        entity.isPlayer = true;
        int shipID = _contexts.game.currentGameSetup.value.shipID;
        _assetViewService.LoadShipAsset(entity, shipID, 0);     // TODO GETMULTIPLIERS INDEX ???   
        var health = entity.baseShipStats.baseShip.health * entity.shipsStatsMultipliers.shipMultipliers.health;
        entity.AddHealth(health, health);
    }

}
