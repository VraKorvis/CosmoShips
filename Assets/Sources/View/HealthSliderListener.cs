using UnityEngine;
using System.Collections;
using Entitas;

public class HealthSliderListener : MonoBehaviour, IEventListener, IEnemiesHealthListener, IGameHealthListener {

    public void RegisterListeners(IEntity entity) {
        var e = (EnemiesEntity)entity;
        e.AddEnemiesHealthListener(this);
    }

    public void OnHealth(EnemiesEntity entity, float value) {
        //TODO 
        //control health slider
        Debug.Log(value);
    }

    public void OnHealth(GameEntity entity, float value) {
        throw new System.NotImplementedException();
    }

}
