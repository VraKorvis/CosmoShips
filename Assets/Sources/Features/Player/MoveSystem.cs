using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using System;

public class MoveSystem : IExecuteSystem {
    private Contexts _contexts;

    public float leftBorder;
    public float rightBorder;
    public float topBorder;
    public float botBorder;

    //private IGroup<GameEntity> _group;
    public MoveSystem(Contexts contexts) {
        _contexts = contexts;
        //_group = contexts.game.GetGroup(GameMatcher.View);          
    }

    public void Execute() {
        var playerEntity = _contexts.game.playerEntity;
        
        if (playerEntity!=null) {

            var playerTransform = playerEntity.view.value.transform;
            var mooveSpeed = playerEntity.baseShipStats.baseShip.mooveSpeed;
            var mooveSpeedMultiply = playerEntity.shipsStatsMultipliers.shipMultipliers.mooveSpeed;

            Vector3 newPosition = playerTransform.position + _contexts.input.input.value * mooveSpeed * mooveSpeedMultiply * Time.deltaTime;

            //playerTransform.Translate(newPosition);

            // Vector3 posLErp = Vector3.Lerp(playerTransform.position, playerTransform.position+ newPosition, mooveSpeedMultiply*Time.deltaTime);
            // playerTransform.position = posLErp;

            Rigidbody rb = playerEntity.unityRigidbody.value.Rigidbody;
            Vector3 newPos = _contexts.input.input.value * mooveSpeed * mooveSpeedMultiply * Time.deltaTime;
            rb.transform.position += newPos;            

            //rb.MovePosition(rb.position + _contexts.input.input.value * mooveSpeed * mooveSpeedMultiply * Time.fixedDeltaTime);


        }

    }


}
