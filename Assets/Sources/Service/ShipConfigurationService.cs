using UnityEngine;
using System.Collections;
using Entitas;

public interface IWeaponHardwareEntity : IEntity, ILaserEntity, ICenterLaserEntity { }
public partial class GameEntity : IWeaponHardwareEntity { }
public partial class EnemiesEntity : IWeaponHardwareEntity { }

public class ShipConfigurationService : Service {
    public ShipConfigurationService(Contexts contexts) : base(contexts) { }

    public void SetupCenterLaser(GameObject viewObject, IWeaponHardwareEntity entity) {
        Transform centerLaserPos = viewObject.transform.GetChildTransformsWithTag("CenterLaser");
        entity.AddCenterLaser(centerLaserPos);
    }

    public void SetupLasers(GameObject viewObject, IWeaponHardwareEntity entity) {
        //load laser
        Transform[] lasersPos = viewObject.transform.GetChildsTransformsWithTag("Lasers");
        entity.AddLaser(lasersPos);
    }

    public void SetupRocket(GameObject viewObject, IWeaponHardwareEntity entity) {
        //load rocket
       
    }
}

