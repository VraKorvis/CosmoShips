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
            Vector3 rotate = _contexts.input.input.value * playerEntity.baseShipStats.baseShip.mooveSpeed * Time.deltaTime;
           
            playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, Quaternion.Euler(30f * _contexts.input.input.value.y, 0.0f, 0.0f),  12 * Time.deltaTime);
           
            //doesnt work without phisix (isKinematic = true)
            //if phisix = on, move in fixedupdate
            //Rigidbody rb = playerEntity.rigidbody.value.rigidBody;
            // rb.rotation = Quaternion.Euler(30f * _contexts.input.input.value.y, 0.0f, 0.0f); 
            //or
            // rb.MoveRotation(Quaternion.Euler(30f * _contexts.input.input.value.x, 0.0f, 0f));

        }
    }
}
