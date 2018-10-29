using Entitas;

public interface IViewService {
     void LoadShipAsset(GameEntity entity, int shipsIndex, int shipMultipliersIndex);

    void LoadWeaponAsset(GameEntity entity, int laserID, int rocketID);
}