﻿using UnityEngine;
using System.Collections;
using Entitas;
using System;

public class ShootCoolDownSystem : IExecuteSystem {

    private Contexts _context;
    IGroup<GameEntity> _coolDowns;

    public ShootCoolDownSystem(Contexts context) {
        _context = context;
        _coolDowns = context.game.GetGroup(GameMatcher.ShootCoolDown);
    }

    public void Execute() {
        Debug.Log(_coolDowns.GetEntities().Length);
        foreach (var e in _coolDowns.GetEntities()) {
            float ticks = (e.shootCoolDown.ticks - Time.deltaTime);
           // Debug.Log("cd ticks: " + e.shootCoolDown.ticks + " deltaTime:  "  + Time.deltaTime);

            if (ticks >=0) {
                e.ReplaceShootCoolDown(ticks);
            } else e.RemoveShootCoolDown();
        }
    }
}