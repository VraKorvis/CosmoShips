using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class ProcessCollisionSystem : ReactiveSystem<InputEntity> {

    private Contexts _contexts;

    public ProcessCollisionSystem(Contexts context) : base(context.input) {
        _contexts = context;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.Collider));
    }

    protected override bool Filter(InputEntity entity) {
        return entity.hasCollider;
    }

    protected override void Execute(List<InputEntity> entities) {
        //Debug.Log("Hit");
        foreach (var e in entities) {
            // Debug.Log("entity collider : " + e);
            var self = (IHealthEntity)e.collider.self;
            self.ReplaceHealth(self.health.value - 1);
            var other = (IHealthEntity)e.collider.other;
            var newEnemyHealth = other.health.value - ((BulletsEntity)self).damage.value;
            other.ReplaceHealth(newEnemyHealth);
        }
    }


}
