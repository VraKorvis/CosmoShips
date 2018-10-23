using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class LevelManager {       

    public static int sceneID = 1;
    public static int shipIndex = 0;

    //private void Awake() {
    //    instance = this;
    //    sceneID = 1;
    //    DontDestroyOnLoad(this);
    //}

    public static IEnumerator Loadlvl(Slider slider, int currentLvl) {
        var s = SceneManager.LoadSceneAsync(sceneID);
        while (!s.isDone) {
            float progress = s.progress/0.9f;
            slider.value = progress;
            yield return null;
        }
    }


}
