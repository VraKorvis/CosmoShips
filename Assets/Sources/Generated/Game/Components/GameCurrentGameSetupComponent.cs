//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity currentGameSetupEntity { get { return GetGroup(GameMatcher.CurrentGameSetup).GetSingleEntity(); } }
    public CurrentGameSetupComponent currentGameSetup { get { return currentGameSetupEntity.currentGameSetup; } }
    public bool hasCurrentGameSetup { get { return currentGameSetupEntity != null; } }

    public GameEntity SetCurrentGameSetup(CurrentGameSetup newValue) {
        if (hasCurrentGameSetup) {
            throw new Entitas.EntitasException("Could not set CurrentGameSetup!\n" + this + " already has an entity with CurrentGameSetupComponent!",
                "You should check if the context already has a currentGameSetupEntity before setting it or use context.ReplaceCurrentGameSetup().");
        }
        var entity = CreateEntity();
        entity.AddCurrentGameSetup(newValue);
        return entity;
    }

    public void ReplaceCurrentGameSetup(CurrentGameSetup newValue) {
        var entity = currentGameSetupEntity;
        if (entity == null) {
            entity = SetCurrentGameSetup(newValue);
        } else {
            entity.ReplaceCurrentGameSetup(newValue);
        }
    }

    public void RemoveCurrentGameSetup() {
        currentGameSetupEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public CurrentGameSetupComponent currentGameSetup { get { return (CurrentGameSetupComponent)GetComponent(GameComponentsLookup.CurrentGameSetup); } }
    public bool hasCurrentGameSetup { get { return HasComponent(GameComponentsLookup.CurrentGameSetup); } }

    public void AddCurrentGameSetup(CurrentGameSetup newValue) {
        var index = GameComponentsLookup.CurrentGameSetup;
        var component = CreateComponent<CurrentGameSetupComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCurrentGameSetup(CurrentGameSetup newValue) {
        var index = GameComponentsLookup.CurrentGameSetup;
        var component = CreateComponent<CurrentGameSetupComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCurrentGameSetup() {
        RemoveComponent(GameComponentsLookup.CurrentGameSetup);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCurrentGameSetup;

    public static Entitas.IMatcher<GameEntity> CurrentGameSetup {
        get {
            if (_matcherCurrentGameSetup == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CurrentGameSetup);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCurrentGameSetup = matcher;
            }

            return _matcherCurrentGameSetup;
        }
    }
}