using UnityEngine;
using System.Collections;
using Entitas;

public interface IEventListener {
    void RegisterListeners(IEntity entity);
}