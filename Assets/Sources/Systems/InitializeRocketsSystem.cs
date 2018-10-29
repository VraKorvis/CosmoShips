using UnityEngine;
using Entitas;
using System.Collections.Generic;
using Entitas.Unity;
using System;
using Object = UnityEngine.Object;

public class InitializeRocketsSystem : IInitializeSystem {

    private Contexts _context;
    public InitializeRocketsSystem(Contexts context) {
        _context = context;
    }

    public void Initialize() {
       // Create 100 rockets
        var weaponSetup = Contexts.sharedInstance.game.weaponSetup.value;
        int count = weaponSetup.rockets.Count;
       for (int i =0; i<1; i++) {
            for (int k = 0; k < count; k++) {
                var r = Object.Instantiate(weaponSetup.rockets[k].type);
                
                var entity = Contexts.sharedInstance.game.CreateEntity();
                entity.AddResource(r);
                entity.isRocketLauncher = true;
                r.Link(entity, _context.game);
            }            
        }
    }
}
