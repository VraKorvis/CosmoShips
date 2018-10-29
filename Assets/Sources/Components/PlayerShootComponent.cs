using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Game, Unique]
public class PlayerShootComponent : IComponent {
    public Vector3 shootLaserPosition;
    public Vector3 shooRocketLeftPosition;
    public Vector3 shooRocketRightPosition;
}
