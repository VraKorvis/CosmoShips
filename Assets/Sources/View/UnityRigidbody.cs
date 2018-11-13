using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(Rigidbody))]
public class UnityRigidbody : MonoBehaviour {
    [SerializeField]
    private Rigidbody rb;

    public Rigidbody Rigidbody => rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }
}