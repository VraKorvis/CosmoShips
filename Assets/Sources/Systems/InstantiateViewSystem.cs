using UnityEngine;
using Entitas;
using System.Collections.Generic;
using Entitas.Unity;
using System;
using Object = UnityEngine.Object;
using System.Linq;

public class InstantiateViewSystem : ReactiveSystem<GameEntity> {

    private ShipConfigurationService _shipConfigurationService;
    private Contexts _contexts;

    public InstantiateViewSystem(Contexts contexts, Services services) : base(contexts.game) {
        _contexts = contexts;
        _shipConfigurationService = services.shipConfigurationService;
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

            // Set laser, rocket, ..., etc
            _shipConfigurationService.SetupLasers(viewObject, entity);
            _shipConfigurationService.SetupCenterLaser(viewObject, entity);
            
        }
    }
    
}

