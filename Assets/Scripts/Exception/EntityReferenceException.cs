using UnityEngine;
using System.Collections;
using System;

public class EntityReferenceException : NullReferenceException {
    public EntityReferenceException(string message) : base(message) {
        Debug.Log(message);
    }
}
