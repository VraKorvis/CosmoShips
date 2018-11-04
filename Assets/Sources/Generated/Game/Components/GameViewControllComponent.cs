//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ViewControllComponent viewControll { get { return (ViewControllComponent)GetComponent(GameComponentsLookup.ViewControll); } }
    public bool hasViewControll { get { return HasComponent(GameComponentsLookup.ViewControll); } }

    public void AddViewControll(IPoolableViewController newController) {
        var index = GameComponentsLookup.ViewControll;
        var component = CreateComponent<ViewControllComponent>(index);
        component.controller = newController;
        AddComponent(index, component);
    }

    public void ReplaceViewControll(IPoolableViewController newController) {
        var index = GameComponentsLookup.ViewControll;
        var component = CreateComponent<ViewControllComponent>(index);
        component.controller = newController;
        ReplaceComponent(index, component);
    }

    public void RemoveViewControll() {
        RemoveComponent(GameComponentsLookup.ViewControll);
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
public partial class GameEntity : IViewControllEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherViewControll;

    public static Entitas.IMatcher<GameEntity> ViewControll {
        get {
            if (_matcherViewControll == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ViewControll);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherViewControll = matcher;
            }

            return _matcherViewControll;
        }
    }
}
