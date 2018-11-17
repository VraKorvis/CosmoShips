using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Bullets, Enemies]
[Event(EventTarget.Self)]
public class HealthComponent : IComponent {
    public float value, max;
}
