using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSystem : IExecuteSystem {
    private Contexts _contexts;

    private IGroup<GameEntity> _group;
    public RotateSystem(Contexts contexts) {
        _contexts = contexts;
        _group = contexts.game.GetGroup(GameMatcher.View);
    }

    public void Execute() {
        var playerEntity = _contexts.game.playerEntity;
        if (playerEntity != null) {

            var playerTransform = playerEntity.view.value.transform;
            Vector3 rotate = _contexts.input.input.value * playerEntity.baseShipStats.baseShip.mooveSpeed *Time.deltaTime;
            playerTransform.rotation = Quaternion.Euler(playerTransform.rotation.x, rotate.y * 0.6f, playerTransform.rotation.z);


        }
    }
}
