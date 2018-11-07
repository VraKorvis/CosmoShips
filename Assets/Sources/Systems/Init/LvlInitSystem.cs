using UnityEngine;
using System.Collections;
using Entitas;
using System;

public class LvlInitSystem : IInitializeSystem {

    private Contexts _context;

    public LvlInitSystem(Contexts context) {
        _context = context;
    }

    public void Initialize() {
        
    }
}
