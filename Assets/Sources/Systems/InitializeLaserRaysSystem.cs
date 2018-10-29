using UnityEngine;
using Entitas;
using System.Collections.Generic;
using Entitas.Unity;
using System;
using Object = UnityEngine.Object;

public class InitializeLaserRaysSystem : IInitializeSystem {

    private Contexts _context;
    public InitializeLaserRaysSystem(Contexts context) {
        _context = context;
    }

    public void Initialize() {

        // Create 100 laser
        var weaponSetup = Contexts.sharedInstance.game.weaponSetup.value;
        int count = weaponSetup.lasers.Count;
        for (int i = 0; i < 1; i++) {
            for (int k = 0; k < count; k++) {
                var l = Object.Instantiate(weaponSetup.lasers[k].type);
                var entity = Contexts.sharedInstance.game.CreateEntity();
                entity.AddResource(l);
                entity.isLaser = true;
                l.Link(entity, _context.game);

            }

        }
    }

}
