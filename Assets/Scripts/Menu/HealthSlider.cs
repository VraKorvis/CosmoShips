using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour {

    public Image fillArea;
    private Slider _slider;    

    private void Awake() {
        _slider = GetComponent<Slider>();        
    }
    
    public void ChangeVal(Slider slider) {
        float val = slider.value/100f;
        //Debug.Log(val);
        fillArea.color = new Color(Color.red.r * (1-val), Color.green.g*val, 0f);
    }
}
