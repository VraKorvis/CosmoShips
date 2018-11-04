using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Entitas.Unity;

public class BulletOutOfScreenSystem : IExecuteSystem {

    private Contexts _context;

    private IGroup<BulletsEntity> _group;

    public BulletOutOfScreenSystem(Contexts context) {
        this._context = context;
        _group = context.bullets.GetGroup(BulletsMatcher.AllOf(BulletsMatcher.Bullet, BulletsMatcher.Rigidbody));
    }

    public void Execute() {
        foreach (var e in _group) {
            
            var pos = e.rigidbody.value.RigidBody.position;
            if (pos.x > 20f) {                
                e.flagOutOfScreen = true;
            }
        }
    }


}
