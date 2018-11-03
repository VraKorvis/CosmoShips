using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;
public class LogCollisionSystem : ReactiveSystem<InputEntity> {

    private Contexts _context;

    public LogCollisionSystem(Contexts context) : base (context.input) {
        _context = context;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
        return context.CreateCollector(InputMatcher.Collider);
    }
   

    protected override bool Filter(InputEntity entity) {
        return entity.hasCollider;
    }

    protected override void Execute(List<InputEntity> entities) {
        foreach (var e in entities) {
         //  Debug.Log("context info : " + e.contextInfo.name + "   hit the enemy : " + e.collider.other);

        }
    }

}
