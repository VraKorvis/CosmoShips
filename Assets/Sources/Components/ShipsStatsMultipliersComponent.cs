using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Game, Unique]
public class ShipsStatsMultipliersComponent : IComponent {
    public ShipMultipliers shipMultipliers;
}
