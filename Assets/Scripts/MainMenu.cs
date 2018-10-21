using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {    
    
    public Slider slider;
    public Button startbtn;
    public GameObject shipPanel;
    public GameObject shipStatsPanel;
    public ShipsStatsUI shipsStatUI;
   
    public GameSetup gameSetup;
    [HideInInspector]
    public int currentIndexship;
    [HideInInspector]
    public GameObject[] shipPrefab;
    [HideInInspector]
    public GameObject currentShip;
    public ShipRotate shipRotate;

    public GameObject viewPosition;

    public Button prevbtn;
    public Button nextbtn;

    private void Awake() {
        currentIndexship = 0;
        startbtn.gameObject.SetActive(true);
        slider.gameObject.SetActive(false);
        shipPrefab = new GameObject[gameSetup.Count()];

        for (int i = 0; i < gameSetup.Count(); i++) {
            shipPrefab[i] = Instantiate(gameSetup[i].type);
            shipPrefab[i].transform.SetParent(shipPanel.transform);
            shipPrefab[i].transform.position = viewPosition.transform.position;
            shipPrefab[i].transform.rotation = viewPosition.transform.rotation;
            shipPrefab[i].transform.localScale = viewPosition.transform.localScale;

            shipPrefab[i].SetActive(false);
        }
        currentShip = shipPrefab[0];
        currentShip.SetActive(true);
        UpdateShipStatsUI(currentIndexship);
    }
    private void Start() {
        shipRotate = GetComponent<ShipRotate>();
        shipRotate.ship = currentShip;
        startbtn.onClick.AddListener(() => StartGame());
        prevbtn.onClick.AddListener(() => Prev());
        nextbtn.onClick.AddListener(() => Next());  
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
            shipRotate.ship = currentShip;
            UpdateShipStatsUI(currentIndexship);
        } else {
            currentIndexship++;
        }
    }
    public void Next() {
        currentIndexship++;
        if (currentIndexship < gameSetup.Count()) {
            currentShip.SetActive(false);
            currentShip = shipPrefab[currentIndexship];
            currentShip.SetActive(true);
            shipRotate.ship = currentShip;
            UpdateShipStatsUI(currentIndexship);
        } else {
            currentIndexship--;
        }
    }

    public void UpdateShipStatsUI(int index) {
         shipsStatUI.health.text = gameSetup.baseShipsStats[index].health.ToString();
        shipsStatUI.shootSpeed.text = gameSetup.baseShipsStats[index].shootSpeed.ToString();
        shipsStatUI.moveSpeed.text = gameSetup.baseShipsStats[index].mooveSpeed.ToString();
        shipsStatUI.mobility.text = gameSetup.baseShipsStats[index].mobility.ToString();
        shipsStatUI.weaponDamage.text = "no found";
    }
   
}
