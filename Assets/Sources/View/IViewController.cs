﻿using Entitas;
using UnityEngine;

public interface IViewController {

    GameObject gameObject { get; }
    Vector3 position { get; set; }

    void Link(Entity entity, IContext icontexts);

    void Show(bool animated);
    void Hide(bool animated);

    void Hide(bool animated, Vector3 hitPos);

    void Reset();

    void InitView(GameObject viewObject, IViewableEntity e);

}