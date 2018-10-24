using UnityEngine;
using UnityEditor;

public interface IRigidbody {

    Vector3 Velocity { get; set; }
    Vector3 Position { get; set; }
    Quaternion Rotation { get; set; }
    Rigidbody rigidBody { get; }
}