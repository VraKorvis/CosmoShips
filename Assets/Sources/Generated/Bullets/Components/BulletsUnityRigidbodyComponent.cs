//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class BulletsEntity {

    public UnityRigidbodyComponent unityRigidbody { get { return (UnityRigidbodyComponent)GetComponent(BulletsComponentsLookup.UnityRigidbody); } }
    public bool hasUnityRigidbody { get { return HasComponent(BulletsComponentsLookup.UnityRigidbody); } }

    public void AddUnityRigidbody(UnityRigidbody newValue) {
        var index = BulletsComponentsLookup.UnityRigidbody;
        var component = CreateComponent<UnityRigidbodyComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceUnityRigidbody(UnityRigidbody newValue) {
        var index = BulletsComponentsLookup.UnityRigidbody;
        var component = CreateComponent<UnityRigidbodyComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveUnityRigidbody() {
        RemoveComponent(BulletsComponentsLookup.UnityRigidbody);
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
public partial class BulletsEntity : IUnityRigidbodyEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class BulletsMatcher {

    static Entitas.IMatcher<BulletsEntity> _matcherUnityRigidbody;

    public static Entitas.IMatcher<BulletsEntity> UnityRigidbody {
        get {
            if (_matcherUnityRigidbody == null) {
                var matcher = (Entitas.Matcher<BulletsEntity>)Entitas.Matcher<BulletsEntity>.AllOf(BulletsComponentsLookup.UnityRigidbody);
                matcher.componentNames = BulletsComponentsLookup.componentNames;
                _matcherUnityRigidbody = matcher;
            }

            return _matcherUnityRigidbody;
        }
    }
}