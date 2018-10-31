using System;
using System.Collections.Generic;
using Entitas;

public sealed class DestroyEntitySystem : IExecuteSystem {

    private Contexts _contexts;

   // Group group;
    public void Execute() {
       // var group = gameContext.GetGroup(GameMatcher.Position);
       // var collector = group.CreateCollector(GroupEvent.Added);
    }

    public void Execute(List<Entity> entities) {
        //foreach (var e in entities) {
        //    foreach (var pool in _pools) {
        //        if (pool.HasEntity(e)) {
        //            pool.DestroyEntity(e);
        //            break;
        //        }
        //    }
        //}
    }

   
}
