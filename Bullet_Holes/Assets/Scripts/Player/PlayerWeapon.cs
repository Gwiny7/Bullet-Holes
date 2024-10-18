using UnityEngine;

namespace BulletHoles
{
    public class PlayerWeapon : MonoBehaviour {
        [SerializeField] GameObject portalPrefab;
        [SerializeField] Transform spawnPoint;
        [SerializeField] float maxTimerPortal = 1.0f;
        float timerPortal = 0.0F;
        InputReader input;
        Portal[] Portals = new Portal[2];
        [SerializeField] GameObject camera;
        GameObject PortalHolder;

        void Awake(){
            Portals[0] = null;
            Portals[1] = null;
            input = GetComponent<InputReader>();
        }
        
        //Regular Fire code
        void Update(){
            timerPortal -= Time.deltaTime;

            if(input.Fire && timerPortal <= 0){
                SpawnPortal(spawnPoint);
            }
        }

        void SpawnPortal(Transform PortalPoint){
            /*if(Portals[0] != null){
                if(Portals[1] != null){
                    Portals[1].DeletePortal();
                }
                Portals[1] = Portals[0].GetComponent<Portal>();
            }
            PortalHolder = Instantiate(portalPrefab, PortalPoint.position, PortalPoint.rotation, camera.transform);
            Portals[0] = PortalHolder.GetComponent<Portal>();
            Portals[0].SetOther(Portals[1]);
            Portals[1].SetOther(Portals[0]);
            timerPortal = maxTimerPortal;

            if(Portals[0] != null){
            
            }*/
        }
    }
}
