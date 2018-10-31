using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(Rigidbody))]
public class UnityRigidbody : MonoBehaviour {
    [SerializeField]
    public Rigidbody _rigidbody;

    void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public Vector3 Velocity {
        get { return _rigidbody.velocity; }
        set { _rigidbody.velocity = value; }
    }

    public Vector3 Position {
        get { return _rigidbody.position; }
        set { _rigidbody.position = value; }
    }

    public Quaternion Rotation {
        get { return _rigidbody.rotation; }
        set { _rigidbody.rotation = value; }
    }

    public Rigidbody rigidBody {
        get {
            return _rigidbody;
        }
    }
}