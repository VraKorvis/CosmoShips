using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using DesperateDevs.Utils;

[Game, Bullets]
public sealed class ViewObjectPoolComponent : IComponent {
    public ObjectPool<GameObject> pool;
}
