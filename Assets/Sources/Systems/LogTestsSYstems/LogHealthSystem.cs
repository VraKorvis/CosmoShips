using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

public interface ILogHealth : IEntity, IHealthEntity { }
public partial class GameEntity : ILogHealth { }
public partial class BulletsEntity : ILogHealth { }
public partial class EnemiesEntity : ILogHealth { }

public class LogHealthSystem : MultiReactiveSystem<ILogHealth, Contexts> {

  //  readonly List<IHealthListener> _listenerBuffer;

    public LogHealthSystem(Contexts contexts) : base(contexts) { }

    protected override ICollector[] GetTrigger(Contexts contexts) {
        return new ICollector[] {
            contexts.game.CreateCollector(GameMatcher.Health),
           // contexts.bullets.CreateCollector(BulletsMatcher.Health),
            contexts.enemies.CreateCollector(EnemiesMatcher.Health)
        };
    }

    protected override bool Filter(ILogHealth entity) {
        return entity.hasHealth;
    }
    protected override void Execute(List<ILogHealth> entities) {
        foreach (var entity in entities) {
            var health = entity.health.value;
            Debug.Log(entity + " health: " + health);

        }
    }



}
