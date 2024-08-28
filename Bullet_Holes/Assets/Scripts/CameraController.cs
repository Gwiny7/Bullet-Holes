using UnityEngine;

namespace BulletHoles
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Transform player;
        [SerializeField] float speed = 2f;

        void Start(){
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }

        void LateUpdate(){
            //Move camera along the battlefield at constant speed
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }
}
