using UnityEngine;
using Entitas;

public class RootSystem : Feature {

    public RootSystem(Contexts contexts, Services services) {

        //Initilize
        Add(new LvlInitSystem(contexts));
        Add(new InitializePlayerSystem(contexts, services));
        Add(new InstantiateViewSystem(contexts, services));

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
       // Add(new ContinuousShootSystem(contexts));   // ongoing shooting   //TODO switching in game
        Add(new LasersShootingSystem(contexts));

        Add(new ShootCoolDownSystem(contexts));
        Add(new ProcessShootSystem(contexts));

        //Collision, Physics
        Add(new ProcessCollisionSystem(contexts));

        //Debug
        //Add(new LogCollisionSystem(contexts));
        //Add(new LogHealthSystem(contexts));

        //ENemy Wave
        Add(new CreateTestEnemyForCheckCollisionSystem(contexts));
        
        //Health control
        Add(new MultiCheckHealthSystem(contexts));        

        //Listener 
        Add(new EnemiesEventSystems(contexts));

        //Destroy
        Add(new MultiDestroySystem(contexts));
        Add(new BulletOutOfScreenSystem(contexts));           

    }
}
