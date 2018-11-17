using UnityEngine;
using System.Collections;
using Entitas;
using System;
using DesperateDevs.Utils;
using Object = UnityEngine.Object;

public class ContinuousShootSystem : IExecuteSystem, IInitializeSystem {

    private Contexts _context;
    private IGroup<InputEntity> _shoots;

    ObjectPool<GameObject> _bulletsObjectPool;

    public ContinuousShootSystem(Contexts context) {
        _context = context;        
    }

    public void Initialize() {
        var lasers = _context.game.weaponSetup.value.lasers;
        var laserID = _context.game.currentGameSetup.value.laserID;
        var laserPrefab = lasers[laserID].type;
        _bulletsObjectPool = new ObjectPool<GameObject>(() => Object.Instantiate(laserPrefab));
        _shoots = _context.input.GetGroup(InputMatcher.ShootInput);
    }

    public void Execute() {
        var playerEntity = _context.game.playerEntity;
        foreach (var e in _shoots.GetEntities()) {   
            
            if (!playerEntity.hasShootCoolDown) {
                var bullet = _context.bullets.CreateEntity();
                // TODO CoolDown should be configurable   
                var lasers = _context.game.weaponSetup.value.lasers;

                var laserID = _context.game.currentGameSetup.value.laserID;
                var weaponCharact = lasers[laserID].weaponCharacteristic;

               // var weapon = Weapon

                playerEntity.AddShootCoolDown(playerEntity.baseShipStats.baseShip.shootSpeed/1000f);

                bullet.AddViewObjectPool(_bulletsObjectPool);

                var damage = weaponCharact.damage;
                bullet.AddDamage(damage);

               
                bullet.isBullet = true;
                bullet.AddHealth(1,1);
            }
        }
    }
   
}
