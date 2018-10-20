using Entitas;

public interface IViewService {
    void LoadAsset(GameEntity entity, string assetName);
    void LoadAsset(GameEntity entity, int shipsIndex, int shipMultipliersIndex);

}