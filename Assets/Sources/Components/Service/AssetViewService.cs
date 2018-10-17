using System;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using Object = UnityEngine.Object;
public class AssetViewService : IViewService {
    
    protected readonly Contexts _contexts;
    public AssetViewService(Contexts contexts) {        
        _contexts = contexts;
    }

    public void LoadAsset(Contexts contexts, GameEntity entity, string assetName) {
        //Object.Instantiate(Resources.Load<GameObject>(string.Format("Prefabs/{0}", assetName)), _root);
    }
    public void LoadAsset(Contexts contexts, GameEntity entity) {

        entity.AddResource(contexts.game.shipsSetup.value.playerShips[0]);
        entity.AddBaseShipStats(_contexts.game.gameSetup.value.baseShipsStats[0]);
        entity.AddHealth(entity.baseShipStats.baseShip.health);

    }
}