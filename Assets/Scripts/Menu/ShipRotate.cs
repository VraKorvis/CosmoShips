using System;
using UnityEngine;
using UnityEngine.EventSystems;

public enum MoveDirection {
    LEFT, RIGHT, UP, DOWN
}

public class ShipRotate : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public static ShipRotate instance;

    public GameObject panelSwype;
   
    public MainMenu mainMenu;
    [HideInInspector]
    public GameObject ship;

    public Touch initTouch;
    private float rotX;
    private float rotY;
    private Vector3 originalRotat;
    private float rotSpeed = 0.5f;
    private float mouseSpeed = 10.0f;

    void Awake() {
        instance = this;
        initTouch = new Touch();
    }

    void Start() {
        ship = mainMenu.currentShip;
        originalRotat = ship.transform.eulerAngles;
        rotX = originalRotat.x;
        rotY = originalRotat.y;
    }

    private void FixedUpdate() {
       // LookShip();

    }

    private void LookShip() {
        foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began) {
                initTouch = touch;
            } else if (touch.phase == TouchPhase.Moved) {
                float deltaY = initTouch.position.x - touch.position.x;
                float deltaX = initTouch.position.y - touch.position.y;
                rotX += deltaX * Time.deltaTime * rotSpeed;
                rotY += deltaY * Time.deltaTime * rotSpeed;
                ship.transform.eulerAngles = new Vector3(rotX, rotY, 0.0f);
            } else if (touch.phase == TouchPhase.Ended) {
                initTouch = new Touch();
            }
        }

        //if (Input.touchCount > 0)
        //    transform.Rotate(Vector3.forward, Input.touches[0].deltaPosition.y * speeds, Space.Self);

    }

    private void LookShipWHithMouse() {
        if (Input.GetButton("Fire1")) {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos != Input.mousePosition) {
                Debug.Log(Input.mousePosition);
                float deltaX = mousePos.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
                float deltaY = mousePos.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
                rotX += Camera.main.ScreenToWorldPoint(Input.mousePosition).x * Time.deltaTime * mouseSpeed;
                rotY += Camera.main.ScreenToWorldPoint(Input.mousePosition).y * Time.deltaTime * mouseSpeed;
                ship.transform.eulerAngles = new Vector3(rotX, rotY, 0.0f);
            }
        }
    }

    //private void OnMouseDrag() {
    //    Debug.Log("click");
    //    float deltaX = ship.transform.rotation.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
    //    float deltaY = ship.transform.rotation.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
    //    if (Input.GetKey(KeyCode.Mouse0)) {
    //        rotY += deltaX * mouseSpeed * Time.deltaTime;
    //        rotX += deltaY * mouseSpeed * Time.deltaTime;
    //    }
    //    ship.transform.rotation = Quaternion.Euler(rotX, rotY, 0.0f);
    //}

    private void MoveKey(GameObject sender, KeyCode keyCode) {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Debug.Log("kRight");
            //   gm.Move(MoveDirection.RIGHT);
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Debug.Log("kLEFT");
            //   gm.Move(MoveDirection.LEFT);
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            Debug.Log("kDOWN");
            //   gm.Move(MoveDirection.DOWN);
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            Debug.Log("kUP");
            //   gm.Move(MoveDirection.UP);
        }
    }

    private Vector3 startPos;
    private Vector3 endPos;

    public void OnBeginDrag(PointerEventData eventData) {
        startPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData) {
        endPos = eventData.position;
        Vector3 newRot = startPos - endPos;
        ship.transform.rotation = Quaternion.Euler(90-newRot.y, newRot.x, -90.0f);
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag + " + eventData);
    }
}
