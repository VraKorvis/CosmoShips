using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBorder : MonoBehaviour {

    public float leftBorder;
    public float rightBorder;
    public float topBorder;
    public float botBorder;

    private void Awake() {
        //float dist = Vector3.Distance(new Vector3(0.0f, 5.0f, 0.0f), Camera.main.transform.position);
        //leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        //rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        //topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
        //botBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        transform.position = new Vector3(Mathf.Clamp(pos.x, leftBorder, rightBorder), Mathf.Clamp(pos.y, botBorder, topBorder), pos.z);
    }
}
