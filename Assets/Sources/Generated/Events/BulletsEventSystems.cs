//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class BulletsEventSystems : Feature {

    public BulletsEventSystems(Contexts contexts) {
        Add(new BulletsHealthEventSystem(contexts)); // priority: 0
    }
}