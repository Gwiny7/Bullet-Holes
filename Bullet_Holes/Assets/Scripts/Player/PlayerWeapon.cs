using UnityEngine;

namespace BulletHoles
{
    public class PlayerWeapon : MonoBehaviour {
        [SerializeField] GameObject portalPrefab;
        [SerializeField] Transform spawnPointJ;
        [SerializeField] Transform spawnPointK;
        [SerializeField] Transform spawnPointL;
        [SerializeField] float maxTimerPortal = 1.0f;
        float timerPortal = 0.0F;
        InputReader input;
        Portal[] Portals = new Portal[2];
        GameObject cam;
        GameObject PortalHolder;

        void Awake(){
            cam = GameObject.Find("Main Camera");
            Portals[0] = null;
            Portals[1] = null;
            input = GetComponent<InputReader>();
        }
        
        //Regular Fire code
        void Update(){
            timerPortal -= Time.deltaTime;

            if(input.FireJ && timerPortal <= 0){
                SpawnPortal(spawnPointJ);
            }

            else if(input.FireK && timerPortal <= 0){
                SpawnPortal(spawnPointK);
            }

            else if(input.FireL && timerPortal <= 0){
                SpawnPortal(spawnPointL);
            }
        }

        void SpawnPortal(Transform PortalPoint){
            if(Portals[0] != null){
                if(Portals[1] != null){
                    Portals[1].DeletePortal();
                }
                Portals[1] = Portals[0].GetComponent<Portal>();
            }
            
            PortalHolder = Instantiate(portalPrefab, PortalPoint.position, PortalPoint.rotation, cam.transform);
            Portals[0] = PortalHolder.GetComponent<Portal>();
            Portals[0].SetOther(Portals[1]);
            Portals[0].SetCamera(cam.transform);
            if(Portals[1] != null){
                Portals[1].SetOther(Portals[0]);
            }

            timerPortal = maxTimerPortal;
        }
    }
}
