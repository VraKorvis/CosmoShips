//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface ICenterLaserEntity {

    CenterLaserComponent centerLaser { get; }
    bool hasCenterLaser { get; }

    void AddCenterLaser(UnityEngine.Transform newValue);
    void ReplaceCenterLaser(UnityEngine.Transform newValue);
    void RemoveCenterLaser();
}