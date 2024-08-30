using UnityEngine;

namespace BulletHoles
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float speed = 5f;
        [SerializeField] float smoothness = 0.1f;
        [SerializeField] float leanAngle = 15f;
        [SerializeField] float leanSpeed = 5f;
        
        [Header("Camera Bounds")]
        [SerializeField] Transform cameraFollow;
        [SerializeField] float minX = -8f;
        [SerializeField] float maxX = 8f;
        [SerializeField] float minY = -1f;
        [SerializeField] float maxY = 4f;

        InputReader input;

        Vector3 currentVelocity;
        Vector3 targetPosition;

        void Start(){
            input = GetComponent<InputReader>();
        }
        
        void Update(){
            targetPosition += new Vector3(input.Move.x, input.Move.y, 0f) * (speed * Time.deltaTime);

            //Calculate the min and max X and Y positions for the player based on the camera view
            float minPlayerX = cameraFollow.position.x + minX;
            float maxPlayerX = cameraFollow.position.x + maxX;
            float minPlayerY = cameraFollow.position.y + minY;
            float maxPlayerY = cameraFollow.position.y + maxY;

            //Clamp the player's position to the camera view
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPlayerX, maxPlayerX);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPlayerY, maxPlayerY);

            //Lerp the player's position to the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothness);

            //Calculate the rotation effect
            /*float targetRotationAngle = -input.Move.x * leanAngle;

            float currentYRotation = transform.localEulerAngles.y;
            float newYRotation = Mathf.LerpAngle(currentYRotation, targetRotationAngle, leanSpeed * Time.deltaTime);

            //Apply rotation effect
            transform.localEulerAngles = new Vector3(0f, newYRotation, 0f);*/
        }
    }
}
