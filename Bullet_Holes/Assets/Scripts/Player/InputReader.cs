using UnityEngine;
using UnityEngine.InputSystem;

namespace BulletHoles
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputReader : MonoBehaviour
    {
       PlayerInput playerInput;
       InputAction moveAction;
       InputAction fireAction;
       InputAction fireAction2;
       InputAction pause;

       public Vector2 Move => moveAction.ReadValue<Vector2>();
       public bool Fire => fireAction.ReadValue<float>() > 0f;
       public bool Fire2 => fireAction2.ReadValue<float>() > 0f;
       public bool Pause => pause.ReadValue<float>() > 0f;

       void Start() {
            playerInput = GetComponent<PlayerInput>();
            moveAction = playerInput.actions["Move"];
            fireAction = playerInput.actions["Fire"];
            fireAction2 = playerInput.actions["Fire2"];
            pause = playerInput.actions["Pause"];
       }
    }
}
