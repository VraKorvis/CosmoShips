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
        return context.CreateCollector(InputMatcher.Collision);
    }

    protected override bool Filter(InputEntity entity) {
        return entity.hasCollision;
    }   

    
    protected override void Execute(List<InputEntity> entities) {
        foreach (var e in entities) {
         //   e.collision.self-1

        }
    }

  
}
