﻿using Entitas;

public interface IViewService {
    void LoadAsset(Contexts contexts, GameEntity entity, string assetName);
    void LoadAsset(Contexts contexts, GameEntity entity);

}