using System;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using Object = UnityEngine.Object;
public class AssetViewService : IViewService {
    
    protected readonly Contexts _contexts;
    public AssetViewService(Contexts contexts) {        
        _contexts = contexts;
    }

    public void LoadAsset(Contexts contexts, GameEntity entity, string assetName) {
        //Object.Instantiate(Resources.Load<GameObject>(string.Format("Prefabs/{0}", assetName)), _root);
    }
    public void LoadAsset(Contexts contexts, GameEntity entity) {
        entity.AddResource(_contexts.game.shipsSetup.value.playerShips[0]);
        entity.AddBaseShipStats(_contexts.game.gameSetup.value.baseShipsStats[0]);

        entity.AddInitialPosition(Vector3.zero);

        var viewObject = Object.Instantiate(entity.resource.prefab);

        if (viewObject == null)
            throw new NullReferenceException("Prefabs not found!");

        entity.AddView(viewObject);

        var rigidbody = viewObject.GetComponent<IRigidbody>();
        if (rigidbody != null)
            entity.AddRigidbody(rigidbody);

        entity.AddPosition(viewObject.transform.position);
        var view = viewObject.GetComponent<IViewService>();

        if (view != null) {
            // view.InitializeView(contexts, entity);
            // entity.AddView(view);
        }

        viewObject.Link(entity, _contexts.game);
        if (entity.hasInitialPosition) {
            viewObject.transform.position = entity.initialPosition.value;
        }
    }
}