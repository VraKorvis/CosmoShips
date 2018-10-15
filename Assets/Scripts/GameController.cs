using System;
using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {
    public GameSetup _gameSetup;
    public ShipsSetup _shipsSetup;

    public Services services;

    private Systems _systems;

    private void Start() {
        var contexts = Contexts.sharedInstance;
        contexts.game.SetGameSetup(_gameSetup);
        contexts.game.SetShipsSetup(_shipsSetup);

        CreateServices(contexts, services);

        _systems = new RootSystem(contexts, services);
        _systems.Initialize();
    }

    private void Update() {
        _systems.Execute();
    }

    private void CreateServices(Contexts contexts, Services services) {
        services.viewService = new AssetViewService(contexts);       
    }

}
