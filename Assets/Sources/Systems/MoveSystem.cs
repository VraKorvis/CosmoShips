using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

public class MoveSystem : IExecuteSystem {
    private Contexts _contexts;
   
    private IGroup<GameEntity> _group;
    public MoveSystem(Contexts contexts) {
        _contexts = contexts;
        _group = contexts.game.GetGroup(GameMatcher.View);        
    }

    public void Execute() {
        var playerEntity = _contexts.game.playerEntity;
        if (playerEntity != null && playerEntity.hasRigidbody) {

            var playerTransform = playerEntity.view.value.transform;
            Vector3 newPosition = _contexts.input.input.value * playerEntity.baseShipStats.baseShip.mooveSpeed *Time.deltaTime ;
            playerTransform.Translate(newPosition);             
            
        }

    }


}
