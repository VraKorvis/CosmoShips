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
            var bulletHealth = e.collider.self as IHealthEntity;
            bulletHealth.ReplaceHealth(bulletHealth.health.value - 1);
            var newEnemyHealth = (e.collider.other as IHealthEntity).health.value - 10;
            (e.collider.other as IHealthEntity).ReplaceHealth(newEnemyHealth);

        }
    }

  
}
