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
        _group = context.bullets.GetGroup(BulletsMatcher.AllOf(BulletsMatcher.Bullet, BulletsMatcher.UnityRigidbody));
    }

    public void Execute() {
        foreach (var e in _group) {
            
            var pos = e.unityRigidbody.value.Rigidbody.position;
            if (pos.y > 20f) {                
                e.flagOutOfScreen = true;
            }
        }
    }


}
