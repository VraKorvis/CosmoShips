using System;
using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {

    public CurrentGameSetup _currentGameSetup;
    public GameSetup _gameSetup;

    public WeaponSetup _weaponSetup;

    public Services _services;

    private Systems _systems;

    private void Start() {
        var contexts = Contexts.sharedInstance;
        contexts.game.SetGameSetup(_gameSetup);       
        contexts.game.SetCurrentGameSetup(_currentGameSetup);
        contexts.game.SetWeaponSetup(_weaponSetup);
        CreateServices(contexts, _services);

        _systems = new RootSystem(contexts, _services);
        _systems.Initialize();
    }

    private void Update() {
        _systems.Execute();
    }

    private void FixedUpdate() {
        //_systems.Execute();
    }

    private void LateUpdate() {
        
    }

    private void CreateServices(Contexts contexts, Services services) {
        _services = new Services();
        _services.viewService = new AssetViewService(contexts);       
    }

}
