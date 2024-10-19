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
       InputAction fireActionJ;
       InputAction fireActionK;
       InputAction fireActionL;
       InputAction pause;

       public Vector2 Move => moveAction.ReadValue<Vector2>();
       public bool Fire => fireAction.ReadValue<float>() > 0f;
       public bool FireJ => fireActionJ.ReadValue<float>() > 0f;
       public bool FireK => fireActionK.ReadValue<float>() > 0f;
       public bool FireL => fireActionL.ReadValue<float>() > 0f;
       public bool Pause => pause.ReadValue<float>() > 0f;

       void Start() {
            playerInput = GetComponent<PlayerInput>();
            moveAction = playerInput.actions["Move"];
            fireAction = playerInput.actions["Fire"];
            fireActionJ = playerInput.actions["FireJ"];
            fireActionK = playerInput.actions["FireK"];
            fireActionL = playerInput.actions["FireL"];
            pause = playerInput.actions["Pause"];
       }
    }
}
