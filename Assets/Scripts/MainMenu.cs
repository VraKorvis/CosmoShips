using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {    
    
    public Slider slider;
    public Button startbtn;
    public GameObject panel;
   
    public ShipsSetup ships;
    [HideInInspector]
    public int currentIndexship;
    [HideInInspector]
    public GameObject[] shipPrefab;
    public GameObject currentShip;

    public GameObject viewPosition;

    public Button prevbtn;
    public Button nextbtn;

    private void Awake() {
        currentIndexship = 0;
        startbtn.gameObject.SetActive(true);
        slider.gameObject.SetActive(false);
        shipPrefab = new GameObject[ships.Count()];
        
        
    }
    private void Start() {        
        startbtn.onClick.AddListener(() => StartGame());
        prevbtn.onClick.AddListener(() => Prev());
        nextbtn.onClick.AddListener(() => Next());
        
        for (int i = 0; i < ships.Count(); i++) {
            shipPrefab[i] = Instantiate(ships[i]);
            shipPrefab[i].transform.SetParent(panel.transform);
            shipPrefab[i].transform.position = viewPosition.transform.position;
            shipPrefab[i].transform.rotation = viewPosition.transform.rotation;
            shipPrefab[i].transform.localScale = viewPosition.transform.localScale;
           
            shipPrefab[i].SetActive(false);
        }
        currentShip = shipPrefab[0];
        currentShip.SetActive(true);
    }

    private void StartGame() {
        slider.gameObject.SetActive(true);
        startbtn.gameObject.SetActive(false);
        StartCoroutine(LevelManager.Loadlvl(slider, LevelManager.sceneID));
    }

    public void Prev() {
        currentIndexship--;
        if (currentIndexship >= 0) {
            currentShip.SetActive(false);
            currentShip = shipPrefab[currentIndexship];
            currentShip.SetActive(true);
        } else {
            currentIndexship++;
        }
    }
    public void Next() {
        currentIndexship++;
        if (currentIndexship < ships.Count()) {
            currentShip.SetActive(false);
            currentShip = shipPrefab[currentIndexship];
            currentShip.SetActive(true);
        } else {
            currentIndexship--;
        }
    }

   
}
