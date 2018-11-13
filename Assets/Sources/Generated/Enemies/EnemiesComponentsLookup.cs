//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class EnemiesComponentsLookup {

    public const int Destroy = 0;
    public const int Enemy = 1;
    public const int Health = 2;
    public const int OutOfScreen = 3;
    public const int UnityRigidbody = 4;
    public const int UnityTransform = 5;
    public const int View = 6;
    public const int ViewControll = 7;
    public const int ViewObjectPool = 8;

    public const int TotalComponents = 9;

    public static readonly string[] componentNames = {
        "Destroy",
        "Enemy",
        "Health",
        "OutOfScreen",
        "UnityRigidbody",
        "UnityTransform",
        "View",
        "ViewControll",
        "ViewObjectPool"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(DestroyComponent),
        typeof(EnemyComponent),
        typeof(HealthComponent),
        typeof(OutOfScreenComponent),
        typeof(UnityRigidbodyComponent),
        typeof(UnityTransformComponent),
        typeof(ViewComponent),
        typeof(ViewControllComponent),
        typeof(ViewObjectPoolComponent)
    };
}
