using UnityEngine;
using System.Collections;
using Entitas;
using System;
using DesperateDevs.Utils;
using Object = UnityEngine.Object;

public class LasersShootingSystem : IInitializeSystem, IExecuteSystem {

    private Contexts _context;

    IGroup<GameEntity> _lasersGroup;
    ObjectPool<GameObject> _bulletsObjectPool;

    public LasersShootingSystem(Contexts contexts) {
        _context = contexts;
    }

    public void Initialize() {
        var lasers = _context.game.weaponSetup.value.lasers;
        var laserID = _context.game.currentGameSetup.value.laserID;
        var laserPrefab = lasers[laserID].type;
                
        _bulletsObjectPool = new ObjectPool<GameObject>(() => Object.Instantiate(laserPrefab));
        _lasersGroup = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.Laser, GameMatcher.CenterLaser));
    }

    public void Execute() {
        var playerEntity = _context.game.playerEntity;
        var positions = playerEntity.laser.value;       
        
        foreach (var entity in _lasersGroup) {

            if (!playerEntity.hasShootCoolDown) {

                playerEntity.AddShootCoolDown(playerEntity.baseShipStats.baseShip.shootSpeed / 1000f);

                for (int i = 0; i < positions.Length; i++) {
                    var bullet = _context.bullets.CreateEntity();
                    bullet.AddViewObjectPool(_bulletsObjectPool);

                    bullet.AddUnityTransform(positions[i]);
                  
                    bullet.isBullet = true;
                    bullet.AddHealth(1f, 1f);

                    var lasers = _context.game.weaponSetup.value.lasers;
                    var laserID = _context.game.currentGameSetup.value.laserID;
                    var weaponCharact = lasers[laserID].weaponCharacteristic;                   

                    var damage = weaponCharact.damage;
                    bullet.AddDamage(damage);
                    bullet.isAssignView = true;
                }
        
            }

        }
    }

}
