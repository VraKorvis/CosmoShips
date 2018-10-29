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
        int shipID = _contexts.game.currentGameSetup.value.shipID;      
        _viewService.LoadShipAsset(entity, shipID, 0);     // TODO GETMULTIPLIERS INDEX ???   
        entity.AddHealth(entity.baseShipStats.baseShip.health * entity.shipsStatsMultipliers.shipMultipliers.health);

        //   _viewService.LoadWeaponAsset(entity, _contexts.game.currentGameSetup.value.laserID, _contexts.game.currentGameSetup.value.rocketID);
        //  InitWeapon(entity);

        var testENtity = _contexts.game.CreateEntity();
        var gotest = _contexts.game.gameSetup.value.baseShipsStats[0].type;
        testENtity.AddView(gotest);

    }

    private void InitWeapon(GameEntity entity) {
        var laser = entity.view.value.transform.GetChild(0);
        var rocketLeft = entity.view.value.transform.GetChild(1);
        var rocketRIght = entity.view.value.transform.GetChild(2);

        entity.AddPlayerShoot(laser.transform.position, rocketLeft.transform.position, rocketRIght.transform.position);
    }

}
