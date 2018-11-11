using UnityEngine;
using System.Collections;

public class EffectsPlayer : MonoBehaviour {

    public static Transform effectViewContainer;
    public string description;
    public GameObject[] effects;

    private void Awake() {
        if (effectViewContainer == null) {
            effectViewContainer = new GameObject("Effect Views").transform;
        }
    }    
}

public static class EffectsPlayerExtension {

    public static GameObject[] Play(this EffectsPlayer effectsPlayer, Vector3 position) {
        if (effectsPlayer == null) {
            return null;
        }
        var effects = new GameObject[effectsPlayer.effects.Length];

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

        return effects;
    }
}