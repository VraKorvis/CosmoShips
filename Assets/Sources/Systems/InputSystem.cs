using Entitas;
using UnityEngine;

public class InputSystem : IExecuteSystem, IInitializeSystem {

    private Contexts _contexts;
    private float speed;

    public InputSystem(Contexts contexts) {
        _contexts = contexts;
    }

    public void Initialize() {

    }

    public void Execute() {
        //var horizontal = Input.GetAxis("Horizontal");
        //var vertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(horizontal, vertical, 0.0f);
        //_contexts.input.ReplaceInput(movement);

        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");

        //_contexts.input.CreateEntity()
        //         .AddMoveInput(new Vector3(moveX, moveY))
        //         .AddInputOwner(PLAYER1_ID);

        Vector3 movement = new Vector3(moveX, moveY, 0.0f);
        _contexts.input.ReplaceInput(movement);

         _contexts.input.inputEntity.isShootInput = true;
        //if (Input.GetAxisRaw("Fire1") != 0) {
        //    _contexts.input.inputEntity.isShootInput = true;

        //} else {
        //    _contexts.input.inputEntity.isShootInput = false;
        //}

        _contexts.input.isSlowMotion = Input.GetAxisRaw("Fire2") != 0;

    }


}
