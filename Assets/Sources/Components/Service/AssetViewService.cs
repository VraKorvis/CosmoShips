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

    public void LoadAsset(GameEntity entity, string assetName) {
        //Object.Instantiate(Resources.Load<GameObject>(string.Format("Prefabs/{0}", assetName)), _root);
    }
    /// <summary>
    /// Ship loading from game setup(ships stats asset)
    /// </summary>
    /// <param name="entity">entity who need add components</param>
    /// <param name="shipsIndex">ship number (player1, player2,..., player5, etc)</param>
    public void LoadAsset(GameEntity entity, int shipsIndex, int shipMultipliersIndex) {
        BaseShip ship = _contexts.game.gameSetup.value.baseShipsStats[shipsIndex];
        ShipMultipliers shipMultipliers = _contexts.game.gameSetup.value.shipsStatsMultipliers[shipMultipliersIndex];
        entity.AddBaseShipStats(ship);
        entity.AddShipsStatsMultipliers(shipMultipliers);
        entity.AddResource(ship.type);        

    }
}