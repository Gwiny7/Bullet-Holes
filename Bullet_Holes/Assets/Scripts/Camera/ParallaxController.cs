using UnityEngine;

namespace BulletHoles
{
    public class ParallaxController : MonoBehaviour
    {
        [SerializeField] Transform[] backgrounds; //array of background layers;
        [SerializeField] float smoothing = 10f; //how smooth the parallax effect is;
        [SerializeField] float multiplier = 15f; //how much the parallax effect increases per layer;

        Transform cam;
        Vector3 previousCamPos;

        void Awake(){
            cam = Camera.main.transform;
        }

        void Start(){
            previousCamPos = cam.position;
        }

        void Update(){
            // Iterate through each background layer
            for(int i = 0; i < backgrounds.Length; i++){
                float parallax = (previousCamPos.y - cam.position.y) * (i * multiplier);
                float targetY = backgrounds[i].position.y + parallax;

                Vector3 targetPosition = new Vector3(backgrounds[i].position.x, targetY, backgrounds[i].position.z);
                backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, targetPosition, smoothing * Time.deltaTime);
            }

            previousCamPos = cam.position;
        }
    }
}
