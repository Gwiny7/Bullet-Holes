using UnityEngine;

namespace BulletHoles
{
    public class PortalSaida : Weapon
    {
        public void Fire(/*Vector3 deslocamento*/){
            
            //Refinar a fórmula para fazer o tiro sair em posição relativa no novo portal

            /*Transform nFirePoint = firePoint;
            nFirePoint.position = firePoint.position + deslocamento;*/
            weaponStrategy.Fire(firePoint, layer);
        }

        public void PlacePortal(Vector3 coords){
            transform.position = coords;
        }   
    }
}
