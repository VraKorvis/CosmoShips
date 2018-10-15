using UnityEngine;
using Entitas;

public class RootSystem : Feature {

    public RootSystem(Contexts contexts, Services services) {
       
        Add(new LogHealthSystem(contexts));
        Add(new InitializePlayerSystem(contexts, services));
        Add(new InstantiateViewSystem(contexts, services));

        Add(new InputSystem(contexts));
        Add(new MoveSystem(contexts));

        Add(new RotateSystem(contexts));
    }
}
