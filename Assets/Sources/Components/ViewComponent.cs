using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Enemies, Bullets]
public class ViewComponent : IComponent {
    [EntityIndex]
    public GameObject value;
}
