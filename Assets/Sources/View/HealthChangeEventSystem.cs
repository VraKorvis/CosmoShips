using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

public class HealthChangeEventSystem : ReactiveSystem<EnemiesEntity> {

    private Contexts _contexts;
    readonly List<IEnemiesHealthListener> _listenerBuffer;

    public HealthChangeEventSystem(Contexts contexts) : base(contexts.enemies) {
        this._contexts = contexts;
        _listenerBuffer = new List<IEnemiesHealthListener>();
    }

    protected override ICollector<EnemiesEntity> GetTrigger(IContext<EnemiesEntity> context) {
        return context.CreateCollector(EnemiesMatcher.Health);
    }
    
    protected override bool Filter(EnemiesEntity entity) {
        return entity.hasHealth; //TODO entity.hasHUDhealthSlider
    }

    protected override void Execute(List<EnemiesEntity> entities) {
        foreach (var entity in entities) {
            var health = entity.health.value;
            //Debug.Log(entity + " health: " + health);
            _listenerBuffer.Clear();           
            _listenerBuffer.AddRange(entity.enemiesHealthListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnHealth(entity, health);
            }
        }
    }

}
