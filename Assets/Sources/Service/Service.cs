using UnityEngine;
using System.Collections;
using System;

public abstract class Service  {

    protected Contexts _contexts;

    protected Service(Contexts contexts) {
        _contexts = contexts;
    }
}
