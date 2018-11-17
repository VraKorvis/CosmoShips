using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public interface ICheckHealthEntity : IEntity, IHealthEntity, IDestroyableEntity  { }

public partial class GameEntity : ICheckHealthEntity { }
public partial class BulletsEntity : ICheckHealthEntity { }
public partial class EnemiesEntity : ICheckHealthEntity { }

public sealed class MultiCheckHealthSystem : MultiReactiveSystem<ICheckHealthEntity, Contexts> {

    private Contexts _context;

    readonly List<IEnemiesHealthListener> _listenerBuffer;
    public MultiCheckHealthSystem(Contexts context) : base(context) {
        this._context = context;
    }

    protected override ICollector[] GetTrigger(Contexts contexts) {
        return new ICollector[] {
            contexts.game.CreateCollector(GameMatcher.Health),
            contexts.bullets.CreateCollector(BulletsMatcher.Health),
            contexts.enemies.CreateCollector(EnemiesMatcher.Health)
        };
    }

    protected override bool Filter(ICheckHealthEntity entity) {
        return entity.hasHealth;
    }

    protected override void Execute(List<ICheckHealthEntity> entities) {
        foreach (var e in entities) {
            var health = e.health.value;
            if (health <= 0) {               
                e.flagDestroy = true;
            }

        }

    }


}
