using UnityEngine;
using Entitas;

public class InitializePlayerSystem : IInitializeSystem {

    private Contexts _contexts;
    public InitializePlayerSystem(Contexts contexts) {
        _contexts = contexts;
    }
    public void Initialize() {
        var entity = _contexts.game.CreateEntity();
        entity.isPlayer = true;    
        entity.AddResource(_contexts.game.shipsSetup.value.playerShips[0]);
        entity.AddBaseShipStats(_contexts.game.gameSetup.value.baseShipsStats[0]); 
        
        entity.AddInitialPosition(Vector3.zero);       
    }
}
