using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Game, Bullets, Enemies]
public class ViewControllComponent : IComponent {
    public IPoolableViewController controller;
}
