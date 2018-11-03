using Entitas;

[Input]
public sealed class CollisionComponent : IComponent {
    public IEntity self;
    public IEntity other;
}
