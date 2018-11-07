using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour {

    public Transform pivot;
    private Transform _transform;
    private Quaternion destRotation = Quaternion.identity;
    public float distance = 5f;
    public float speedRotation = 10f;
    private float rotX = 0f;
    private float rotY = 0f;
    private void Awake() {
        _transform = GetComponent<Transform>();
    }
    // Use this for initialization
    public void MoveOrbiter() {
        float horz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        rotX += vert * speedRotation * Time.deltaTime;
        rotY -= horz * speedRotation * Time.deltaTime;
       

		Vector3 startTEst = transform.rotation * Vector3.forward;

       
        float alfa = rotX;
        Quaternion YRot = Quaternion.Euler(0f, rotY, 0f);
        destRotation = YRot * Quaternion.Euler(rotX, 0f, 0f);
        _transform.rotation = destRotation;

        alfa = Mathf.Deg2Rad * alfa;
        startTEst = _transform.rotation * Vector3.forward;        
       
        Vector3 forw = new Vector3(1f,0f,1f);

        float xn = Mathf.Cos(alfa) * (0 ) + Mathf.Sin(alfa) * (1);
        float yn = -Mathf.Sin(alfa) * (0) + Mathf.Cos(alfa) * (1);
        float zn = 1;
    
        Vector3 nv = new Vector3(xn, 0, yn) * -distance;
      
        _transform.position = pivot.position + nv;


    }
	
	// Update is called once per frame
	void Update () {
        // MoveOrbiter();
        float horz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        rotX += vert * speedRotation * Time.deltaTime;
        rotY -= horz * speedRotation * Time.deltaTime;

        Quaternion YRot = Quaternion.Euler(0f, rotY, 0f);
        destRotation = YRot * Quaternion.Euler(rotX, 0f, 0f);

        _transform.rotation = destRotation;
        // квантерион * вектор = вектор с углами поворота в квантернионе
        Vector3 quantToVect = transform.rotation * Vector3.forward;
        Vector3 newPos = quantToVect * -distance;


        _transform.position = pivot.position + newPos;


    }

  
}
