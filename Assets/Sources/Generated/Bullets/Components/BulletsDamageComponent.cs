//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class BulletsEntity {

    public DamageComponent damage { get { return (DamageComponent)GetComponent(BulletsComponentsLookup.Damage); } }
    public bool hasDamage { get { return HasComponent(BulletsComponentsLookup.Damage); } }

    public void AddDamage(int newValue) {
        var index = BulletsComponentsLookup.Damage;
        var component = CreateComponent<DamageComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceDamage(int newValue) {
        var index = BulletsComponentsLookup.Damage;
        var component = CreateComponent<DamageComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveDamage() {
        RemoveComponent(BulletsComponentsLookup.Damage);
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
public partial class BulletsEntity : IDamageEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class BulletsMatcher {

    static Entitas.IMatcher<BulletsEntity> _matcherDamage;

    public static Entitas.IMatcher<BulletsEntity> Damage {
        get {
            if (_matcherDamage == null) {
                var matcher = (Entitas.Matcher<BulletsEntity>)Entitas.Matcher<BulletsEntity>.AllOf(BulletsComponentsLookup.Damage);
                matcher.componentNames = BulletsComponentsLookup.componentNames;
                _matcherDamage = matcher;
            }

            return _matcherDamage;
        }
    }
}
