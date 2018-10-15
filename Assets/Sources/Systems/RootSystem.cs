using UnityEngine;
using Entitas;

public class RootSystem : Feature {

    public RootSystem(Contexts contexts) {
       
        Add(new LogHealthSystem(contexts));
        Add(new InitializePlayerSystem(contexts));
        Add(new InstantiateViewSystem(contexts));

        Add(new InputSystem(contexts));
        Add(new MoveSystem(contexts));

        Add(new RotateSystem(contexts));
    }
}
