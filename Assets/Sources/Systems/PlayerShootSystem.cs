using UnityEngine;
using System.Collections;
using Entitas;
using System;
using System.Collections.Generic;
using DesperateDevs.Utils;
using Object = UnityEngine.Object;

public class PlayerShootSystem : ReactiveSystem<InputEntity>, IInitializeSystem {

    private Contexts _contexts;

    ObjectPool<GameObject> _bulletsObjectPool;

    public PlayerShootSystem(Contexts contexts) : base(contexts.input) {
        _contexts = contexts;
    }

    public void Initialize() {
        // Assets.Instantiate<GameObject>(Res.Bullet);
        var weaponID = _contexts.game.currentGameSetup.value.laserID;
        var laserPrefab = _contexts.game.weaponSetup.value.lasers[weaponID].type;
        _bulletsObjectPool = new ObjectPool<GameObject>(() => Object.Instantiate(laserPrefab));       
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
        return context.CreateCollector(InputMatcher.ShootInput);
    }

    protected override bool Filter(InputEntity entity) {
        return entity.isShootInput;
    }

    protected override void Execute(List<InputEntity> entities) {
        var playerEntity = _contexts.game.playerEntity;
        foreach (var e in entities) {
           
           
            if (e.isShootInput) {

                // TODO CoolDown should be configurable
                // e.AddBulletCoolDown(7);

                var velX = 1;
                var velY = 1;
                var velocity = new Vector3(velX, velY, 0);
                var bullet = _contexts.bullets.CreateEntity();
                bullet.AddViewObjectPool(_bulletsObjectPool);                
                bullet.isRay = true;
                bullet.isBullet = true;
                bullet.AddHealth(1);
               
                
            }
        }
    }

}
