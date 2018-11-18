using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Entitas.Unity;

//TODO MultyAddViewFromObjectPool
public sealed class AddViewFromObjectPoolSystem : ReactiveSystem<BulletsEntity> {
      
    Transform _container;

    public AddViewFromObjectPoolSystem(Contexts contexts) : base(contexts.bullets) {
        _container = new GameObject(Contexts.sharedInstance.bullets.contextInfo.name + " Views (Pooled)").transform;
        var pos = new Vector3(0, 0, 0.5f);
        _container.position = pos;
    }  

    protected override ICollector<BulletsEntity> GetTrigger(IContext<BulletsEntity> context) {
        return context.CreateCollector(BulletsMatcher.Bullet);
    }

    protected override bool Filter(BulletsEntity entity) {
        return entity.hasViewObjectPool;
    }   

    protected override void Execute(List<BulletsEntity> entities) {
        
        foreach (var e in entities) {
            GameObject gameObject = e.viewObjectPool.pool.Get();
            gameObject.SetActive(true);
            gameObject.transform.SetParent(_container, false);
            ChangeMaterial(gameObject);
            e.AddView(gameObject);
            gameObject.Link(e, Contexts.sharedInstance.bullets);
          
            var urb = gameObject.GetComponent<UnityRigidbody>();
            if (urb!=null) {
                e.AddUnityRigidbody(urb);
                e.unityRigidbody.value.Rigidbody.transform.position = e.unityTransform.value.position;
                e.unityRigidbody.value.Rigidbody.transform.rotation = e.unityTransform.value.localRotation;
                //OR
               // e.unityRigidbody.value.Rigidbody.transform.rotation = ShootingAtAnAngle(e); 
            }
            var viewController = gameObject.GetComponent<IPoolableViewController>();
            e.AddViewControll(viewController);
        }
    }
    //TODO IF UPDATE!
    //make shooting with degree
    private Quaternion ShootingAtAnAngle(BulletsEntity e) {
       
        Vector3 old = e.unityTransform.value.localRotation.eulerAngles;
        return Quaternion.Euler(old.x, old.z, -old.y);
    }

    private void ChangeMaterial(GameObject go) {
        var material = Resources.Load<Material>(Res.RayLaser + RayLaser.Red);    
        go.GetComponent<Renderer>().sharedMaterial = material;
    }

}
