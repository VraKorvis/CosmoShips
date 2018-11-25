using UnityEngine;
using System.Collections;
using DesperateDevs.Utils;
using System;

public class EffectsPlayer : MonoBehaviour {

    public static Transform effectViewContainer;
    public string description;
    public GameObject[] effects;
    private GameObject _tmpEffect;

    private void Awake() {
        if (effectViewContainer == null) {
            effectViewContainer = new GameObject("Effect Views").transform;
        }
    }

    public GameObject Play(ObjectPool<GameObject> poolEffect, Vector3 position) {
        var effectGO = poolEffect.Get();
        effectGO.SetActive(true);
        effectGO.transform.SetParent(EffectsPlayer.effectViewContainer, false);
        effectGO.transform.position = position;

        var partsSys = effectGO.GetComponentsInChildren<ParticleSystem>();
        var totalDuration = 0f;
        foreach (var ps in partsSys) {
            float duration = ps.main.duration + ps.main.startDelay.constantMax + ps.main.startLifetime.constantMax;
            if (duration > totalDuration) {
                totalDuration = duration;
            }
        }
        _tmpEffect = effectGO;
        Invoke("HideHitEffect", totalDuration);
        return effectGO;

    }

    private void HideHitEffect() {
        _tmpEffect.SetActive(false);
        Singleton<ManagerEffectsPool>.Instance._hitPool.Push(_tmpEffect);
    }


}

public static class EffectsPlayerExtension {

   
    public static void PlayAll(this EffectsPlayer effectsPlayer, Vector3 position) {
        if (effectsPlayer == null) {
            return;
        }        

        foreach (var effect in effectsPlayer.effects) {
            var effectGO = Assets.Clone(effect);

            effectGO.transform.SetParent(EffectsPlayer.effectViewContainer, false);
            effectGO.transform.position = position;

            var partsSys = effectGO.GetComponentsInChildren<ParticleSystem>();
            var totalDuration = 0f;
            foreach (var ps in partsSys) {
                float duration = ps.main.duration + ps.main.startDelay.constantMax + ps.main.startLifetime.constantMax;
                if (duration > totalDuration) {
                    totalDuration = duration;
                }
            }
            Assets.Destroy(effectGO, totalDuration);
        }        
    }
  
}

public class  ManagerEffectsPool : MonoBehaviour {

    public ObjectPool<GameObject> _hitPool = new ObjectPool<GameObject>(() => Assets.Instantiate<GameObject>(Res.HitBullet));
    public ObjectPool<GameObject> _exsplosionPool = new ObjectPool<GameObject>(() => Assets.Instantiate<GameObject>(Res.Explosion_2));

   

  

}
