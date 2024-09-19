using UnityEngine;

namespace BulletHoles
{
    public class PlayerWeapon : MonoBehaviour {
        InputReader input;
        Vector3 spawnPoint;
        [SerializeField] PortalSaida portalSaida;
        [SerializeField] PortalEntrada portalEntrada;


        void Awake(){
            input = GetComponent<InputReader>();
        }
        
        //Regular Fire code
        void Update(){
            spawnPoint = Input.mousePosition;
            spawnPoint = Camera.main.ScreenToWorldPoint(spawnPoint);
            spawnPoint = new Vector3(spawnPoint.x, spawnPoint.y, 0);

            if(input.Fire){
                portalSaida.PlacePortal(spawnPoint);
            }
            if(input.Fire2){
                portalEntrada.PlacePortal(spawnPoint);
            }
        }
    }
}
