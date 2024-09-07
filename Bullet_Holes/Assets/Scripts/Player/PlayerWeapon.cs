using UnityEngine;

namespace BulletHoles
{
    public class PlayerWeapon : MonoBehaviour {
        InputReader input;
        [SerializeField] Transform spawnPoint;
        [SerializeField] PortalSaida portalSaida;


        void Awake(){
            input = GetComponent<InputReader>();
        }
        
        //Regular Fire code
        void Update(){
            if(input.Fire){
                portalSaida.PlacePortal(spawnPoint);
            }
        }
    }
}
