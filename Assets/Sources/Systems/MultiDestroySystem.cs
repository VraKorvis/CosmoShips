using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public interface IDestroyableEntity : IEntity, IDestroyEntity, IViewControllEntity, IOutOfScreenEntity, IUnityRigidbodyEntity { }

public partial class GameEntity : IDestroyableEntity { }
public partial class BulletsEntity : IDestroyableEntity { }
public partial class EnemiesEntity : IDestroyableEntity { }

public class MultiDestroySystem : MultiReactiveSystem<IDestroyableEntity, Contexts> {
    private Contexts _contexts;

    public MultiDestroySystem(Contexts contexts) : base(contexts) {
        this._contexts = contexts;
    }

    protected override ICollector[] GetTrigger(Contexts contexts) {
        return new ICollector[] {
            contexts.game.CreateCollector(GameMatcher.Destroy),
            contexts.bullets.CreateCollector(BulletsMatcher.AnyOf(BulletsMatcher.Destroy, BulletsMatcher.OutOfScreen)),
            contexts.enemies.CreateCollector(EnemiesMatcher.AnyOf(EnemiesMatcher.Destroy, EnemiesMatcher.OutOfScreen))
        };
    }

    protected override bool Filter(IDestroyableEntity entity) {
        return entity.flagDestroy || entity.flagOutOfScreen;
    }

    protected override void Execute(List<IDestroyableEntity> entities) {
        foreach (var e in entities) {
            if (e.hasViewControll) {
                e.viewControll.controller.Hide(!e.flagOutOfScreen, e.unityRigidbody.value.transform.position);
                e.Destroy();
            }
        }
    }     

}
