using UnityEngine;
using Entitas;

public class RootSystem : Feature {

    public RootSystem(Contexts contexts, Services services) {
       
        Add(new LogHealthSystem(contexts));
        Add(new InitializePlayerSystem(contexts, services.viewService));
        Add(new InstantiateViewSystem(contexts, services.viewService));

        Add(new InputSystem(contexts));
        Add(new MoveSystem(contexts));

        Add(new RotateSystem(contexts));

        Add(new PlayerShootSystem(contexts));

        Add(new AddViewFromObjectPoolSystem(contexts));

        Add(new ProcessShootSystem(contexts));


    }
}
