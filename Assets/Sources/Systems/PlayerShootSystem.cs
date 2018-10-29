using UnityEngine;
using System.Collections;
using Entitas;
using System;

public class PlayerShootSystem : ISystem, IExecuteSystem {

    private Contexts _contexts;

    public PlayerShootSystem(Contexts contexts) {
        _contexts = contexts;
    }

    public void Execute() {
        var playerEntity = _contexts.game.playerEntity;
        if (playerEntity != null) {
            //if (Input.GetButton("Fire")) {

            //}
        }
    }
}
