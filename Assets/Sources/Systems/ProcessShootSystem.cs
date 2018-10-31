using UnityEngine;
using System.Collections;
using Entitas;
using System;
using System.Collections.Generic;
using DesperateDevs.Utils;
using Object = UnityEngine.Object;

public class ProcessShootSystem : IExecuteSystem {

    private IGroup<BulletsEntity> _group;
    private Contexts _contexts;

    public ProcessShootSystem(Contexts contexts) {
        _group = contexts.bullets.GetGroup(BulletsMatcher.AllOf(BulletsMatcher.Rigidbody, BulletsMatcher.Bullet, BulletsMatcher.Ray)); //TODO addLaser component
        _contexts = contexts;
    }

    public void Execute() {       
        foreach (var e in _group) {            
            var rb = e.rigidbody.value._rigidbody;
            rb.transform.position += Vector3.right * 75 * Time.deltaTime;
        }
    }

   
}
