//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class InputComponentsLookup {

    public const int Collider = 0;
    public const int Collision = 1;
    public const int Input = 2;
    public const int ShootInput = 3;

    public const int TotalComponents = 4;

    public static readonly string[] componentNames = {
        "Collider",
        "Collision",
        "Input",
        "ShootInput"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(ColliderComponent),
        typeof(CollisionComponent),
        typeof(InputComponent),
        typeof(ShootInputComponent)
    };
}
