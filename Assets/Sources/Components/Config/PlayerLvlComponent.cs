using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
[Event(EventTarget.Self)]
public class PlayerLvlComponent : IComponent {
    public int lvl; 
}
