using UnityEngine;
using Entitas;
using System.Collections.Generic;
using Entitas.Unity;
using System;
using Object = UnityEngine.Object;
using System.Linq;

public class InstantiateViewSystem : ReactiveSystem<GameEntity> {

    private IViewService _viewService;
    private Contexts _contexts;

    public InstantiateViewSystem(Contexts contexts, IViewService viewService) : base(contexts.game) {
        _contexts = contexts;
        _viewService = viewService;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Resource);
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasResource;
    }

    protected override void Execute(List<GameEntity> entities) {
        foreach (var entity in entities) {

            var viewObject = Object.Instantiate(entity.resource.prefab);

            if (viewObject == null)
                throw new NullReferenceException("Prefabs not found!");

            entity.AddView(viewObject);

            UnityRigidbody rigidbody = viewObject.GetComponent<UnityRigidbody>();
            if (rigidbody != null)
                entity.AddUnityRigidbody(rigidbody); //TODO Start POS

            viewObject.Link(entity, _contexts.game);
            Transform[] lasersPos = viewObject.transform.GetChildsTransformsWithTag("Lasers");
            entity.AddLaser(lasersPos);
           // lasersPos.ToList().ForEach(p => Debug.Log(p.localEulerAngles));

        }
    }

}

public static class FindChildExtension {
    public static Vector3[] GetChildsPositionsWithTag(this Transform transform, string tagName) {
        Func<Transform, bool> predicate = tag => tag.tag == tagName;
        return transform.GetComponentsInChildren<Transform>().Where((t) => t.tag == tagName).Select(t => t.position).ToArray(); 
    }

    public static Transform[] GetChildsTransformsWithTag(this Transform transform, string tagName) {
        Func<Transform, bool> predicate = tag => tag.tag == tagName;
        return transform.GetComponentsInChildren<Transform>().Where(predicate).ToArray();
    }

    //public static Vector3[] GetChildsWithTag(this Transform transform, string tagName) {

    //    return transform.GetComponentsInChildren<Transform>()
    //        .filter(t->t.tag.equals(tagName)) 
    //        .map(t->t.transform).toList();  
    //}

}
