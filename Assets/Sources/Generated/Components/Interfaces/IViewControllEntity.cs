//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IViewControllEntity {

    ViewControllComponent viewControll { get; }
    bool hasViewControll { get; }

    void AddViewControll(IPoolableViewController newController);
    void ReplaceViewControll(IPoolableViewController newController);
    void RemoveViewControll();
}
