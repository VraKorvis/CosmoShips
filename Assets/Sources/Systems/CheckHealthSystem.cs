using System.Collections.Generic;
using Entitas;

public sealed class CheckHealthSystem : ReactiveSystem<InputEntity> {

    private Contexts context;
    public CheckHealthSystem(Contexts context) : base(context.input) {
        this.context = context;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
        return context.CreateCollector(InputMatcher.Input);
    }

    protected override bool Filter(InputEntity entity) {
        return entity.hasCollider;
    }
     

    protected override void Execute(List<InputEntity> entities) {
        foreach (var e in entities) {
         //   if (e.health.value <= 0) {
            //     e.flagDestroy = true;
        }


    }
}
