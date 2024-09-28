using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BulletHoles
{
    public class PortalEntrada : MonoBehaviour
    {
        [SerializeField] Transform firePoint;
        [SerializeField] PortalSaida portalSaida;

        void OnCollisionEnter(Collision collision){
            //Vector3 deslocamento = collision.transform.position - firePoint.position;
            portalSaida.Fire();
        }

        public void PlacePortal(Vector3 coords){
            transform.position = coords;
        }
    }
}
