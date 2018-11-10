using UnityEngine;
using Entitas;

public class RootSystem : Feature {

    public RootSystem(Contexts contexts, Services services) {



        //Initilize
        Add(new LvlInitSystem(contexts));
        Add(new InitializePlayerSystem(contexts, services.viewService));
        Add(new InstantiateViewSystem(contexts, services.viewService));

        //Add ViewComponent(RigidBody), ... etc
        Add(new AddViewFromObjectPoolSystem(contexts));
        Add(new AddEnemyViewFromObjectPoolSystem(contexts));

        //Input
        Add(new InputSystem(contexts));

        //Movement, Rotate
        Add(new MoveSystem(contexts));
        Add(new RotateSystem(contexts));

        //Shoot
        //  Add(new PlayerShootSystem(contexts));   // botton shooting 
        Add(new ContinuousShootSystem(contexts));   // ongoing shooting   //TODO switching in game
        Add(new ShootCoolDownSystem(contexts));
        Add(new ProcessShootSystem(contexts));

        //Collision, Physics
        Add(new ProcessCollisionSystem(contexts));


        //Debug
        Add(new LogCollisionSystem(contexts));
        Add(new LogHealthSystem(contexts));
        Add(new CreateTestEnemyForCheckCollisionSystem(contexts)); 
        Add(new MultiCheckHealthSystem(contexts));

        //Destroy
        Add(new MultiDestroySystem(contexts));
        Add(new BulletOutOfScreenSystem(contexts));
           

    }
}
