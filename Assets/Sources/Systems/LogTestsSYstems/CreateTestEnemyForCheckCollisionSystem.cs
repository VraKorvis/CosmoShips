using UnityEngine;
using System.Collections;
using Entitas;
using DesperateDevs.Utils;
using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

public class CreateTestEnemyForCheckCollisionSystem : ReactiveSystem<EnemiesEntity>, IInitializeSystem {

    private Contexts _contexts;
    private ObjectPool<GameObject> _enemyObjectPool;

    public CreateTestEnemyForCheckCollisionSystem(Contexts context) : base(context.enemies) {
        this._contexts = context;
    }
    
    protected override ICollector<EnemiesEntity> GetTrigger(IContext<EnemiesEntity> context) {
        return context.CreateCollector(EnemiesMatcher.Health);
    }

    protected override bool Filter(EnemiesEntity entity) {
        return entity.hasHealth;
    }

    public void Initialize() {
        int enemyIndex = 0;
        var enemyPrefab = _contexts.game.gameSetup.value.baseShipStatsEnemy[enemyIndex].type;
        _enemyObjectPool = new ObjectPool<GameObject>(() => Object.Instantiate(enemyPrefab));

        var enemyEntity = _contexts.enemies.CreateEntity();
        enemyEntity.AddHealth(1000);
        enemyEntity.AddViewObjectPool(_enemyObjectPool);
        // enemyEntity.AddRigidbody();

    }

    protected override void Execute(List<EnemiesEntity> entities) {
        
    }

  
}
