//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface ILaserEntity {

    LaserComponent laser { get; }
    bool hasLaser { get; }

    void AddLaser(UnityEngine.Transform[] newValue);
    void ReplaceLaser(UnityEngine.Transform[] newValue);
    void RemoveLaser();
}