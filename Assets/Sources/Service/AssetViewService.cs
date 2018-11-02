﻿using System;
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

    /// <summary>
    /// Ship loading from game setup(ships stats asset)
    /// </summary>
    /// <param name="entity">entity who need add components</param>
    /// <param name="shipsIndex">ship number (player1, player2,..., player5, etc)</param>
    public void LoadShipAsset(GameEntity entity, int shipsIndex, int shipMultipliersIndex) {
        BaseShip ship = _contexts.game.gameSetup.value.baseShipsStats[shipsIndex];
        ShipMultipliers shipMultipliers = _contexts.game.gameSetup.value.shipsStatsMultipliers[shipMultipliersIndex];
        if (ship != null) {
            entity.AddBaseShipStats(ship);
            entity.AddResource(ship.type);
        }
        if (shipMultipliers != null) {
            entity.AddShipsStatsMultipliers(shipMultipliers);
        }
    }

    public void LoadWeaponAsset(GameEntity entity, int laserID, int rocketID) {
        Laser laser = _contexts.game.weaponSetup.value.lasers[laserID];
        Rocket rocket = _contexts.game.weaponSetup.value.rockets[rocketID];

        if (rocket != null) {
            entity.AddResource(laser.type);
        }
        if (laser != null) {
            entity.AddResource(rocket.type);
        }


    }
}