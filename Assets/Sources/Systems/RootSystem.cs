using UnityEngine;
using Entitas;

public class RootSystem : Feature {

    public RootSystem(Contexts contexts, Services services) {
       
       

        //Initilize
        Add(new InitializePlayerSystem(contexts, services.viewService));
        Add(new InstantiateViewSystem(contexts, services.viewService));

        //Add ViewComponent(RigidBody), ... etc
        Add(new AddViewFromObjectPoolSystem(contexts));
        Add(new AddEnemyViewFromObjectPoolSystem(contexts));

        //Input
        Add(new InputSystem(contexts));

        //Move, Rotate, SHoot, ..., etc, Physics
        Add(new MoveSystem(contexts));
        Add(new RotateSystem(contexts));
        Add(new PlayerShootSystem(contexts));
        Add(new ProcessShootSystem(contexts));
        Add(new ProcessCollisionSystem(contexts));

        Add(new LogCollisionSystem(contexts));

        //Debug
        Add(new LogHealthSystem(contexts));
        Add(new CreateTestEnemyForCheckCollisionSystem(contexts)); 
        Add(new MultiCheckHealthSystem(contexts));

        //Destroy
        Add(new MultiDestroySystem(contexts));
        Add(new BulletOutOfScreenSystem(contexts));
           

    }
}
