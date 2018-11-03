using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

public class LogHealthSystem : ReactiveSystem<GameEntity> {   
    public LogHealthSystem(Contexts contexts) : base(contexts.game) {}   
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Health);
    }
    protected override bool Filter(GameEntity entity) {
        return entity.hasHealth;
    }
    protected override void Execute(List<GameEntity> entities) {
        foreach (var entity in entities) {
            var health = entity.health.value;
            Debug.Log(entity + " health: " + health);
        }
    }

   
}
