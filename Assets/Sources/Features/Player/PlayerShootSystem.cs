using UnityEngine;
using System.Collections;
using Entitas;
using System;
using System.Collections.Generic;
using DesperateDevs.Utils;
using Object = UnityEngine.Object;

public class PlayerShootSystem : ReactiveSystem<InputEntity>, IInitializeSystem {

    private Contexts _context;

    ObjectPool<GameObject> _bulletsObjectPool;

    public PlayerShootSystem(Contexts contexts) : base(contexts.input) {
        _context = contexts;
    }

    public void Initialize() {
        // Assets.Instantiate<GameObject>(Res.Bullet);
        var lasers = _context.game.weaponSetup.value.lasers;
        var laserID = _context.game.currentGameSetup.value.laserID;
        var laserPrefab = lasers[laserID].type;
        _bulletsObjectPool = new ObjectPool<GameObject>(() => Object.Instantiate(laserPrefab));
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
        return context.CreateCollector(InputMatcher.ShootInput);
    }

    protected override bool Filter(InputEntity entity) {
        return entity.isShootInput;
    }

    protected override void Execute(List<InputEntity> entities) {
        var playerEntity = _context.game.playerEntity;
        foreach (var e in entities) {

            if (!playerEntity.hasShootCoolDown) {
                var bullet = _context.bullets.CreateEntity();
                // TODO CoolDown should be configurable   
                var lasers = _context.game.weaponSetup.value.lasers;
                var laserID = _context.game.currentGameSetup.value.laserID;
                var weaponCharact = lasers[laserID].weaponCharacteristic;
                playerEntity.AddShootCoolDown(weaponCharact.speed / 1000f);

                bullet.AddViewObjectPool(_bulletsObjectPool);

                var damage = weaponCharact.damage;
                bullet.AddDamage(damage);

                bullet.isBullet = true;
                bullet.AddHealth(1);
            }
        }
    }

}
