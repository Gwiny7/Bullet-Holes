using UnityEngine;

namespace BulletHoles
{
    public class SplineDeleter : MonoBehaviour {
        [SerializeField] float limit = 8f; 
        Transform cam;

        void Awake(){
            cam = GameObject.Find("Main Camera").GetComponent<Transform>();
        }
        
        void Update(){
            if(transform.position.x < cam.position.x - limit){
                Destroy(gameObject);
            }
        }
    }
}
