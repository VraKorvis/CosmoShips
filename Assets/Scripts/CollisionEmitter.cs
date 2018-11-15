using Entitas;
using Entitas.Unity;
using System;
using UnityEngine;

public class CollisionEmitter : MonoBehaviour {

    public string targetTag;

    // OnCollisionEnter вызывается, когда этот collider/rigidbody начал соприкосновение с другим rigidbody/collider.

    // В отличие от OnTriggerEnter, в OnCollisionEnter передаётся класс Collision, 
    //     а не Collider.Класс Collision содержит информацию о точках соприкосновения, 
    //скорости воздействия и т.д.Если вы не используете CollisionInfo в функции, опустите параметр collisionInfo,
    //     чтобы избежать ненужных вычислений. 
    //Обратите внимание, что события о столкновениях присылаются
    //только если один из коллайдеров так-же имеет присоединенный rigidbody с выключенным параметром IsKinematic

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag(targetTag)) {
            var link = gameObject.GetEntityLink();
            var targetLink = collision.gameObject.GetEntityLink();

            Contexts.sharedInstance.input.CreateEntity()
                .AddCollision(link.entity, targetLink.entity);
        }
    }

    //for !iskinematic
    private void OnTriggerEnter(Collider other) {   
        if (!string.IsNullOrEmpty(targetTag) && other.gameObject.CompareTag(targetTag)) {

            try {
                var self = gameObject.GetEntityLink();
                // because Hierarchy is Pool/Enemy/model .. and we need to do Enemy link (not pool and not model)
                var parent = other.gameObject.transform.parent;
                var gandPa = parent.gameObject.transform.parent;
                // if grandPa cant get link we take parent link
                var targetLink = gandPa?.gameObject.GetEntityLink() ?? parent.gameObject.GetEntityLink();
               
                var colliderEntity = Contexts.sharedInstance.input.CreateEntity();
                colliderEntity.AddCollider(self.entity, targetLink.entity);
            }catch (NullReferenceException e) {
                new EntityReferenceException("No collison because cant GetEntityLink for object, check hierarchy");
            }
        }
    }
}
