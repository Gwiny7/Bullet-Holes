using UnityEngine;

namespace BulletHoles
{
    public class PortalSaida : Weapon
    {
        //[SerializeField] Transform firepoint;

        public void Fire(/*float deslocamento*/){
            
            //Refinar a fórmula para fazer o tiro sair em posição relativa no novo portal

            /*Transform nFirePoint;
            nFirePoint = firepoint;
            nFirePoint.position = new Vector3 (nFirePoint.position.x + deslocamento, nFirePoint.position.y, nFirePoint.position.z);*/
            weaponStrategy.Fire(firePoint, layer);
        }

        public void PlacePortal(Transform coords){
            transform.position = coords.position;
        }   
    }
}
