using UnityEngine;
using System.Collections;
using Entitas;
using DesperateDevs.Utils;
using Entitas.Unity;
using UnityEngine.UI;

public class HealthBarViewListener : MonoBehaviour, IEventListener, IEnemiesHealthListener {

    private string percent = "%";
    public Color healthFull = Color.green, healthZero = Color.red;

    //public Slider healthSlider;
    //public Image healthImage;
    public Transform _barTransform;
    public MeshRenderer _renderer;

    public void RegisterListeners(IEntity entity) {
        var e = (EnemiesEntity)entity;
        e.AddEnemiesHealthListener(this);
    }

    public void UpdateHealth(float health) {
        //Vector3 newScale = _barTransform.localScale;
        //newScale.x = value;
        //_barTransform.localScale = newScale;
        // _renderer.sharedMaterial.color = gradient.Evaluate(value);
        // percentHP.text = value.ToString() + "%";

        //healthSlider.value = health;
        //healthImage.color = Color.Lerp(healthFull, healthZero, health);
    }

    public void OnHealth(EnemiesEntity entity, float value, float max) {
        var newScale = _barTransform.localScale;
        float percent = value / max;
        newScale.x = percent;
        _barTransform.localScale = newScale;
        _renderer.sharedMaterial.color = Color.Lerp(healthZero, healthFull, percent);
        
    }
}
