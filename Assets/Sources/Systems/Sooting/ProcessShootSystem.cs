﻿using UnityEngine;
using System.Collections;
using Entitas;
using System;
using System.Collections.Generic;
using DesperateDevs.Utils;
using Object = UnityEngine.Object;

public class ProcessShootSystem : IExecuteSystem {

    private IGroup<BulletsEntity> _groupLasers;
    private Contexts _context;

    public ProcessShootSystem(Contexts contexts) {
        _groupLasers = contexts.bullets.GetGroup(BulletsMatcher.AllOf(BulletsMatcher.UnityRigidbody, BulletsMatcher.UnityTransform, BulletsMatcher.Bullet)); //TODO addLaser component
        _context = contexts;
    }

    public void Execute() {
        var playerEntity = _context.game.playerEntity;
        ShootRay(playerEntity);

    }

    private void ShootRay(GameEntity playerEntity) {
        Vector3 shootVector = ((PlayerViewController)playerEntity?.viewControll?.controller)?._shootVector ?? Vector3.up;

        foreach (var e in _groupLasers) {
            var rb = e.unityRigidbody.value.Rigidbody;
            var id = _context.game.currentGameSetup.value.laserID;
            var speed = _context.game.weaponSetup.value.lasers[id].weaponCharacteristic.speed;

            rb.transform.position += shootVector * speed * Time.deltaTime;


        }



    }



}