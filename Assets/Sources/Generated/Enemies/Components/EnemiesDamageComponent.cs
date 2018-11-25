//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class EnemiesEntity {

    public DamageComponent damage { get { return (DamageComponent)GetComponent(EnemiesComponentsLookup.Damage); } }
    public bool hasDamage { get { return HasComponent(EnemiesComponentsLookup.Damage); } }

    public void AddDamage(int newValue) {
        var index = EnemiesComponentsLookup.Damage;
        var component = CreateComponent<DamageComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceDamage(int newValue) {
        var index = EnemiesComponentsLookup.Damage;
        var component = CreateComponent<DamageComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveDamage() {
        RemoveComponent(EnemiesComponentsLookup.Damage);
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
public partial class EnemiesEntity : IDamageEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class EnemiesMatcher {

    static Entitas.IMatcher<EnemiesEntity> _matcherDamage;

    public static Entitas.IMatcher<EnemiesEntity> Damage {
        get {
            if (_matcherDamage == null) {
                var matcher = (Entitas.Matcher<EnemiesEntity>)Entitas.Matcher<EnemiesEntity>.AllOf(EnemiesComponentsLookup.Damage);
                matcher.componentNames = EnemiesComponentsLookup.componentNames;
                _matcherDamage = matcher;
            }

            return _matcherDamage;
        }
    }
}
