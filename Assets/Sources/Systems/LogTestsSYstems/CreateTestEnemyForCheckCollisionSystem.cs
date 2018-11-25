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
        return context.CreateCollector(EnemiesMatcher.Enemy);
    }

    protected override bool Filter(EnemiesEntity entity) {
        return entity.isEnemy;
    }

    public void Initialize() {
        int enemyIndex = 1;
        var enemyPrefab = _contexts.game.gameSetup.value.baseShipStatsEnemy[enemyIndex].type;
        _enemyObjectPool = new ObjectPool<GameObject>(() => Object.Instantiate(enemyPrefab));
        for (int i = 0; i < 1; i++) {       

            var enemyEntity = _contexts.enemies.CreateEntity();

            enemyEntity.AddViewObjectPool(_enemyObjectPool);
            enemyEntity.isEnemy = true;
            enemyEntity.AddHealth(1000, 1000);
            enemyEntity.isAssignView = true;
            enemyEntity.AddDamage(10000);
            enemyEntity.isAssignWay = true;
            enemyEntity.AddWaveNumber(0);
        }       
        

    }

    protected override void Execute(List<EnemiesEntity> entities) {
        foreach (var e in entities) {
           // Debug.Log("change or create enemy : " + e); //worked
        }
    }

  
}
