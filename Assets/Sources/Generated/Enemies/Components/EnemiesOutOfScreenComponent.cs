//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class EnemiesEntity {

    static readonly OutOfScreenComponent outOfScreenComponent = new OutOfScreenComponent();

    public bool isOutOfScreen {
        get { return HasComponent(EnemiesComponentsLookup.OutOfScreen); }
        set {
            if (value != isOutOfScreen) {
                var index = EnemiesComponentsLookup.OutOfScreen;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : outOfScreenComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class EnemiesEntity : IOutOfScreenEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class EnemiesMatcher {

    static Entitas.IMatcher<EnemiesEntity> _matcherOutOfScreen;

    public static Entitas.IMatcher<EnemiesEntity> OutOfScreen {
        get {
            if (_matcherOutOfScreen == null) {
                var matcher = (Entitas.Matcher<EnemiesEntity>)Entitas.Matcher<EnemiesEntity>.AllOf(EnemiesComponentsLookup.OutOfScreen);
                matcher.componentNames = EnemiesComponentsLookup.componentNames;
                _matcherOutOfScreen = matcher;
            }

            return _matcherOutOfScreen;
        }
    }
}