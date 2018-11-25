using Entitas;
using System.Collections.Generic;


public class GenerateWaveEnemiesSystem : ReactiveSystem<EnemiesEntity> {

    private Contexts _contexts;
    
    public GenerateWaveEnemiesSystem(Contexts context) : base(context.enemies) {
        this._contexts = context;
    }
    protected override ICollector<EnemiesEntity> GetTrigger(IContext<EnemiesEntity> context) {
        return context.CreateCollector(EnemiesMatcher.AllOf(EnemiesMatcher.Enemy));
    }

    protected override bool Filter(EnemiesEntity entity) {
        return entity.isAssignWay;
    }   

    protected override void Execute(List<EnemiesEntity> entities) {
        foreach (var e in entities) {
           // MoveToNextPos(e);
            e.move.value.Move(e, 5f);
        }
    }


}
