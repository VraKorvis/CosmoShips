using UnityEngine;
using System.Collections;
using Entitas;

[Input]
public class ColliderComponent : IComponent {
    public IEntity self;
    public IEntity other;
}
