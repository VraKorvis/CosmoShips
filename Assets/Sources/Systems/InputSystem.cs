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
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0.0f);
        _contexts.input.ReplaceInput(movement);

    }


}
